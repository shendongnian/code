    public void Configuration(IAppBuilder app)
    {
        app.UseCors(CorsOptions.AllowAll);
    
        var formatters = configuration.Formatters;
    
        //-- Disable XML support
        formatters.XmlFormatter.SupportedMediaTypes.Clear();
            
        var jsonFormatter = formatters.JsonFormatter;
        jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json-patch+json"));
        jsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
        jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        jsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        jsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
    }
