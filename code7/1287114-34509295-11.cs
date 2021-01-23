    public class Temp
    {
        public string Name { get; set; }
    }
    public class MyException : Exception
    {
        public MyException(string name, string age)
            : base($"Name: {name} and Age: {age}")
        { }
        public MyException()
            : base("No parameter")
        { }
    }
