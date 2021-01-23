    void Main()
    {
        Console.WriteLine(typeof(CustomWebServiceBase).GetCustomAttributes().First());
        Console.WriteLine(typeof(SomeSiteService).GetCustomAttributes().First());
        Console.WriteLine(typeof(AnotherSiteService).GetCustomAttributes().First());
    }
    
    [WebService(
         Namespace = "http://CanI.InheritThis.com/",
         Name = "WebServiceBaseClass",
         Description = "This Webservice is overloaded on specific websites")]
    public class CustomWebServiceBase : WebService
    {
    }
    
    public class SomeSiteService : CustomWebServiceBase
    {
    }
    
    [WebService(
         Namespace = "http://YesU.Can.AndOverride.it/",
         Name = "WebServiceDerivedClass",
         Description = "This Webservice is for a specific website")]
    public class AnotherSiteService : CustomWebServiceBase
    {
    }
