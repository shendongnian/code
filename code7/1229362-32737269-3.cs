      public static class MyClass {
        public static String SomeField;
        ....
      }
    
      // the class is static, no instances are allowed
      var o = new MyClass(); // <- Compile time error! 
