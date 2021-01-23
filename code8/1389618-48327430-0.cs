    The answer before is correct, but if you want to enable CORS in all of controllers, you can do that on really easy way: Just in WebApiConfig class, inside of Register method add next two lines:
    
    public static class WebApiConfig
    {
       public static void Register(HttpConfiguration config)
       {
           //This part enables CORS for all controllers
    -->       var cors = new EnableCorsAttribute("*", "*", "*");
    -->       config.EnableCors(cors);  
       }
    }
