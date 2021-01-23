      public class Email {
        ...
        public static implicit operator Email(String value) {
          if (...) // validate value here
            return null; // <- not a actual Email
    
          // Email
          return new Email(value);
        }
      }
    
      ....
    
      Email email = "SomeAddress@SomeServer.com";
    
      if (email != null) {
        ...
      }
