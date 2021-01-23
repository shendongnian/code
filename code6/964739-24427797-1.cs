    public class CodesIncremental
    {
        private AutoResetEvent _event = new AutoResetEvent(true);
    
        public static bool GetNewCodes()
        {
            if(!_event.WaitOne(0))
               return true; //is running
            try
            {
            /*
               actions in case if isn't running
            */
            }
            finally
            {
             _event.Set();
            }
            return false;
    
        }
    }
