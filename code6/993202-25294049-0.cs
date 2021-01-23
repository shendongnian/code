    #define MY_DEBUG //Note: this must be the first line in the file
    
    public static class INFO
    {
        public static void WriteLine(string message)
        {
             #if (MY_DEBUG)
                 Log.writeline(message);
             #else
                 Console.Writeline(message);
             #endif
        }
    }
