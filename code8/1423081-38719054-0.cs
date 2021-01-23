    var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
        formatter.SerializerSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Objects,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
