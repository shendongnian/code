    // Prior to C# 6...
    public class MyService
    {
         private static string WouldBeNice { get { return typeof(MyService).Namespace; } }
    }
    // Now using C# 6...
    public class MyService
    {
         private static string WouldBeNice => typeof(MyService).Namespace;
    }
