    public class CodesIncremental
    {
        private AutoResetEvent _event = new AutoResetEvent(true);
    
        public static bool GetNewCodes()
        {
            if(!_event.WaitOne(0))
               return true; //is running
            /*
               actions in case if isn't running
            */
             _event.Set();
             return false;
    
        }
    }
