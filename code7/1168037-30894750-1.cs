    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ...
            //typical route configs to allow file extensions
            config.Routes.MapHttpRoute("ext", "{controller}/{id}.{ext}");
            config.Routes.MapHttpRoute("default", "{controller}/{id}", new { id = RouteParameter.Optional });
            //remove any default formatters such as xml
            config.Formatters.Clear();
            //order of formatters matter!
            //let's put JSON in as the default first
            config.Formatters.Add(new JsonMediaTypeFormatter());
        
            //now we add our custom formatter
            config.Formatters.Add(new JpegFormatter());
        }
    }
