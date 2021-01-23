       public static TypeExtensions
        {
            public static int NumberOfProperties(this Type value)
            {
                if (null == value)
                  throw new ArgumentNullException("value"); // or return 0
        
                // Length: no need in Linq here
                return value.GetProperties().Length;
            }
        }
    
        ...
    
        
        // How many properties does C507 type have?
        int propCount = typeof(C507).NumberOfProperties(); 
