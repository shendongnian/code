    public class CodesIncremental
    {
        static Int32 _running = 0;
        public static bool GetNewCodes()
        {
            if (Interlocked.CompareExchange(ref _running, 1, 0) == 1)
                return false;
            try
            {
                // Do stuff...
                return true;
            }
            finally
            {
                _running = 0;
            }
        }
    }
