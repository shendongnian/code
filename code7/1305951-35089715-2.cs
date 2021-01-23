    class HASPClass
    {
      private static HASPClass _instance;
      private HASPClass(..)
      {
        //..  Init some other properties
      }
      public static GetInstance(...)
      {
          // Note, if called with different parameters then this will be
          // quite a bit more complicated
          if (_instance == null) 
          { 
              _instance = new HASPClass(...)
          }
          return _instance;
      }
    }
