      public class Person {
        // Private (or protected) Constructor to ensure using factory methods
        private Person(String name) { 
          if (null == name)
            name = "SomeDefaultValue";
          //TODO: put relevant code here
        }
    
        // Factory method, please notice "static"
        public static Person CreateWithName(String name) {
          return new Person(name); 
        }
    
        // Factory method, please notice "static"
        public static Person CreateEmpty() {
          return new Person(null); 
        } 
      }
