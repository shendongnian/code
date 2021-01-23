    private void ConfigureWebApi(HttpConfiguration httpConfig)
        {
            httpConfig.MapHttpAttributeRoutes();
            var jsonFormatter = httpConfig.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
        }
