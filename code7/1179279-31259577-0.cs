        config.EnableCors();
        var json = config.Formatters.JsonFormatter;
        json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
        json.SerializerSettings.ContractResolver = new
            CamelCasePropertyNamesContractResolver();
        config.Formatters.Remove(config.Formatters.XmlFormatter);
