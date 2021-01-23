    public inteface IErrorHandler
    {
        void HandleError(string errorMessage);
    }
    public class ErrorHandler : IErrorHandler
    {
        public void HandleError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }
    }
    public class YourClass: YourSuperClass
    {
        public IErrorHandler ErrorHandler { get; } = new ErrorHandler();
        public void DoSomething()
        {
            this.ErrorHandler.HandleError("Error, I did something!");
        }
    }
