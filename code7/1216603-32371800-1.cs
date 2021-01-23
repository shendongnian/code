    public class Manager
    {
        BasicErrorHandler _errorHandler;
    
        public Manager()
        {
            _errorHandler = new BasicErrorHandler();
        }
    
        public void MethodA()
        {
            _errorHandler.Do(() => {
                //Does Something    
            });
        }
    
        public void MethodB()
        {
            _errorHandler.Do(() => {
                //Does Something Else
            });
        }
    }
