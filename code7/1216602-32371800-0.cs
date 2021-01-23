    public class BasicErrorHandler
    {
        public void ProcessException(Exception ex)
        {
            //Does error handling stuff
        }
        
        public void Do(Action act)
        {
            try
            {
                act();
            }
            catch(Exception ex)
            {
                ProcessException(ex);
            }
        }
    }
