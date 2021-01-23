    using System.Reflection;
    
    namespace mynamespace {
      class MyClass() {
         void test() {
           var tMethods = typeof(DSRObject).DeclaringType.GetRuntimeMethods();
         }
      }
    }
