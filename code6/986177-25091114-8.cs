    // NOTE: necessary using directive - requiring a corresponding reference to
    // System.Web.Services.dll
    using System.Web.Services;
    
    namespace MyServiceWebApp
    {
        // NOTE: the key - the overriding decoration of the derived web-service
        // class with WebServiceAttribute
        [WebService(
         Namespace = "http://YesU.Can.AndOverride.it/",
         Name = "WebServiceDerivedClass",
         Description = "This Webservice is for a specific website")]
        public class MyService : WebServiceClassLibrary.CustomWebServiceBase
        {
    
        }
    }
