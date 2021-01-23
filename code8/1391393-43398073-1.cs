        services.Configure<MvcOptions>(options =>
        {
            options.RespectBrowserAcceptHeader = true;
            // Input formatters
            var xmlInputFormatting = new IBatchCollectionXmlSerializer();
            var jsonInputFormatting = new JsonInputFormatter();
            jsonInputFormatting.SerializerSettings.Converters.Add(new BatchContentConverter());
            options.InputFormatters.Clear();
            options.InputFormatters.Add(jsonInputFormatting);
            options.InputFormatters.Add(xmlInputFormatting);
        }
        
    
 
