    using BCr = BCrypt.Net;
    namespace Program {
       public class MyClass {
         public void MyMethod() {
            var s = BCr.BCrypt.HashPassword("234");
         }
      }
    }
