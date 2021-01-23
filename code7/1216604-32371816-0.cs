    public class manager
    {
        BasicErrorHandler _errorHandler;
    
        public Manager()
        {
            _errorHandler = new BasicErrorHandler();
        }
    
        public void MethodA()
        {
            DoWork( () => {
                // do something interesting here
            });
        }
    
        public void MethodB()
        {
            DoWork( () => {
                // do something else interesting here
            });  
        }
    
        private void DoWork(Action action)
        {
            try
            {
                action();
            }
            catch(Exception ex)
            {
                _errorHandler.ProcessException(ex);
            }
        }
    }
