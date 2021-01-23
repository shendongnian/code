    public class MyException : Exception
    {
        MyException(int severity, string message) : base(message)
        {
            // do whatever you want with severity
        }
    }
