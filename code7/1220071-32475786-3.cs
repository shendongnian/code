    var settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ContractResolver = new DictionaryAsArrayResolver(),
            Converters = new JsonConverter[] {new MyConverter()}
        };
