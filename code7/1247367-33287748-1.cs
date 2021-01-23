      static class test
      {
           private static object _locker = new object();
           static test() 
           { /* ... code */}
            public static void log(string msg)
            {
               lock(_locker )
               { /* ... code */}
            }
      }
