    void Main()
    {
        Console.WriteLine(typeof(Test).GetCustomAttributes().First());
        Console.WriteLine(typeof(Test2).GetCustomAttributes().First());
        Console.WriteLine(typeof(Test3).GetCustomAttributes().First());
    }
    
    [WebService(
         Namespace = "http://CanI.InheritThis.com/",
         Name = "WebServiceBaseClass",
         Description = "This Webservice is overloaded on specific websites")]
    public class Test
    {
    }
    
    public class Test2 : Test
    {
    }
    
    [WebService(
         Namespace = "http://YesU.Can.AndOverride.it/",
         Name = "WebServiceDerivedClass",
         Description = "This Webservice is also overloaded on specific websites")]
    public class Test3 : Test
    {
    }
