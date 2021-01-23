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
    try
    {
    	new Temp().ConditionalThrow(t => true, () => new MyException("Alberto", "25"));
    }
    catch (MyException ex)
    {
    	Console.WriteLine(ex.Message);
    }
    
    try
    {
    	new Temp().ConditionalThrow(t => true, () => new MyException());
    }
    catch (MyException ex)
    {
    	Console.WriteLine(ex.Message);
    }
