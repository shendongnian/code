     public static class WebApiConfig
     {
         public static void Register(HttpConfiguration config)
         {
              ...
              config.Services.Replace(typeof(IHttpControllerSelector),
                  new CustomControllerSelector(config));
              ...
         }
     }
