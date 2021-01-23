    public static ObjectExtensions
    {
        public static int NumberOfProperties(this object value)
        {
            if (null == value)
              throw new ArgumentNullException("value"); // or return 0
    
            // Length: no need in Linq here
            return value.GetType().GetProperties().Length;
        }
    }
    ...
    C507 myObj = new C507();
    // How many properties does myObj instance have?
    int propCount = myObj.NumberOfProperties(); 
