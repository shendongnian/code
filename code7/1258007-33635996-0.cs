    // This class is used both as a dummy parameter for overload resolution
    // and to hold the GetMyName method. You can call it whatever you want
    class QueryMethodNameHelper
    {
      private QueryMethodNameHelper() { }
      public static readonly QueryMethodNameHelper Instance = 
        new QueryMethodNameHelper();
  
      public static string GetMyName([CallerMemberName] string 
        name = "[unknown]")
      {
        return name;
      }
    }
    class Program
    {
      // The real method
      static void SayHello()
      {
        Console.WriteLine("Hello!");
      }
      // The dummy method; the parameter is never used, but it ensures
      // we can have an overload that returns the string name
      static string SayHello(QueryMethodNameHelper dummy)
      {
        return QueryMethodNameHelper.GetMyName();
      }
      // Second real method that has an argument
      static void DoStuff(int value)
      {
        Console.WriteLine("Doing stuff... " + value);
      }
      // Dummy method can use default parameter because
      // there is no ambiguity
      static string DoStuff(QueryMethodNameHelper dummy = null)
      {
        return QueryMethodNameHelper.GetMyName();
      }
      static void Main(string[] args)
      {
        string s = SayHello(QueryMethodNameHelper.Instance);
        Console.WriteLine(s);
        SayHello();
        string s2 = DoStuff();
        Console.WriteLine(s2);
        DoStuff(42);
      }
    }
