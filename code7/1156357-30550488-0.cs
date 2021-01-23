    public static class Logger
    {
        private bool bNoError = true;
        public static void Log()
        {
            if (!bNoError)
            {
                //Then execute the logic here
            }
            else
            {
                //else condition logic here
            }
        }
    
        public static bool IsAnyError()
        {
            return !bNoError;
        }
    } 
