    class B {
         private string usernameFromA;
         public B (string tmpUsername) {
            usernameFromA = tmpUsername;
         }
         public void processC() {
            var c_obj = new c(usernameFromA); 
         }
      }
