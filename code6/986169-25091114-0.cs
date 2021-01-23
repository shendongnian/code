    void Main()
    {
        var test = new Test();
        var test2 = new Test2();
        
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
         Namespace = "http://YesU.Can...AndOverride.it/",
         Name = "WebServiceBaseClass",
         Description = "This Webservice is overloaded on specific websites")]
    public class Test3 : Test
    {
    }
