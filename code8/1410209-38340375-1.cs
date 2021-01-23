    var settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.All,
        ContractResolver = UntypedToTypedValueContractResolver.Instance,
        Converters = new [] { new StringEnumConverter() }, // If you prefer
    };
    var json = JsonConvert.SerializeObject(dict, Formatting.Indented, settings);
    var dict2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(json, settings);
