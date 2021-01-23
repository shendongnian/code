    var settings = new JsonSerializerSettings
    {
        ContractResolver = new DynamicMappingResolver(map)
    };
    var root = JsonConvert.DeserializeObject<RootObject>(json, settings);
