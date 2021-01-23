    public interface IErrorHandling { }
    public static void HandleError(this IErrorHandling errorHandler, string errorMessage)
    {
        Console.WriteLine(errorMessage);
    }
    public class YourClass : YourSuperClass, IErrorHandling
    {
        public void DoSomething()
        {
            this.HandleError("Error, I did something!");
        }
    }
