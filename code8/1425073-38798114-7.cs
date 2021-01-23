    var settings = new JsonSerializerSettings 
    {
        TypeNameHandling = TypeNameHandling.Auto,
        ContractResolver = UntypedToTypedPropertyContractResolver.Instance,
    };
    var json = JsonConvert.SerializeObject(example, Formatting.Indented, settings);
    var example2 = JsonConvert.DeserializeObject<Example>(json, settings);
