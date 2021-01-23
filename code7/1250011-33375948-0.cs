    public class Item {
       public string Body {get;set;}
       public string TimeStamp {get;set;}
       // rest of properties
    }
    public class SomeObject {
       public string Kind {get;set;}
       public string[] Tags  {get;set;}
       public Item[] Items {get;set;}
       // rest of properties
    }
    
    
    // your method in the web api controller
    public IHttpActionResult Index([FromBody] SomeObject myObject) {
     // your validation and action code here and then return some result
    }
    
    // update your web api configuration registration to convert camel case json to pascal cased c# and back again
    public static class WebApiConfig {
            public static void Register(HttpConfiguration config)
            {
                // makes all WebAPI json results lower case
                var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
                json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    // rest of code
