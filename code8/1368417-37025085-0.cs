      public class Parameters {
        private static Lazy<String> s_LoadType = new Lazy<string>(() => {
          ....
          return "bla-bla-bla";
        });
    
        public static String LoadType {
          get {
            return s_LoadType.Value;
          }
        }
        ... 
      }
