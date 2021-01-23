    public class MyException : Exception
    {
        public string SomeProperty { get; set; }
        public MyException(string message, string someProperty, Exception innerException)
            : base(message, innerException)
        {
            SomeProperty = someProperty;
        }
    }
