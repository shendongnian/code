    interface IErrorHandler
    {
        void Warning();
        void Error();
    }
    class VeryGoodErrorHandler : IErrorHandler
    {
        public void Warning()
        {
            // a lot of difficult code
        }
        public void Error()
        {
            // even more difficult code
        }
    }
    class DBEngine : IErrorHandler
    {
        private IErorHandler myErrorHandler = new VeryGoodErrorHandler()
 
        public void Warning()
        {
            this.myErrorHandler.Warning();
        }
        public void Error()
        {
            this.myErrorHandler.Error();
        }
