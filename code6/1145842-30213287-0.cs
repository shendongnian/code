    public class Demo<T> : IDemo where T : IParser
    {
        // ...
    }
    public interface IParser
    {
        Dictionary<int,string> MyParsingMethod();
    }
    public class Test : IParser
    {
        // ...
    }
