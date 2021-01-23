         var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    .....
                };
         settings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
         settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
         settings.Binder = new SomeSerializationBinder(new DefaultSerializationBinder());
    
         var result = JsonConvert.SerializeObject(yourObject, settings);
