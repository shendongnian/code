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
    // Also using C# 6...
    public class MyService
    {
         // This can be even better, because this sets the namespace 
         // to the auto-generated backing class field created during compile-time
         private static string WouldBeNice { get; } = typeof(MyService).Namespace;
    }
