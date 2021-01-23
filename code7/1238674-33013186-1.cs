    class DBEngine : IErrorHandler
    {
        private IErorHandler myErrorHandler = null;
        
        public DBEngine()
        {   // use default error handler:
            myErrorHandler = new VeryGoodErrorHandler();
        }
        public DBEngine(IErrorHandler userProvidedErrorHandler)
        {   // use default error handler:
            myErrorHandler = userProvidedErrorHandler
        }
                public void Warning()
        {
            this.myErrorHandler.Warning();
        }
        public void Error()
        {
            this.myErrorHandler.Error();
        }
    }
