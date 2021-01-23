    public static class WebApiConfig
    {
       public static void Register(HttpConfiguration config)
       {
           // These next two lines enables CORS for all controllers
           var cors = new EnableCorsAttribute("*", "*", "*");
           config.EnableCors(cors);  
       }
    }
