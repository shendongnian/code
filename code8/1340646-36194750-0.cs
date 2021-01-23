    public static class MyExtensions
        {
            public static string ToCustomFormat(this DateTime yourTime)
            {
                      // Get the following var out of the database
          String format = "MM/dd/yyyy hh:mm:sszzz";
    
          // Converts the local DateTime to a string 
          // using the custom format string and display.
          String result = yourTime.ToString(format);
          return result;
            }
        }   
