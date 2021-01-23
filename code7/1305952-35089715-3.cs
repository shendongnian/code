      private static object lockObj = new object();
      public static GetInstance(...)
      {
          // Note, if called with different parameters then this will be
          // quite a bit more complicated
          if (_instance == null) 
          { 
              lock (lockObj)
              {
                  if (_instance == null)
                  {
                      _instance = new HASPClass(...)
                  }
              }
          }
          return _instance;
      }
