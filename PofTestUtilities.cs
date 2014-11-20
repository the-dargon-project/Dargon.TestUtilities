using System.IO;
using Dargon.PortableObjects;
using NMockito;

namespace Dargon {
   public static class PofTestUtilities {
      public static void CheckConfiguration<TPortableObject>(IPofContext context, TPortableObject testObj) 
         where TPortableObject : IPortableObject {
         var serializer = new PofSerializer(context);
         using (var ms = new MemoryStream()) {
            serializer.Serialize(ms, testObj);
            ms.Position = 0;
            var deserialized = serializer.Deserialize<TPortableObject>(ms);
            NMockitoStatic.AssertEquals(testObj, deserialized);
         }
      }
   }
}
