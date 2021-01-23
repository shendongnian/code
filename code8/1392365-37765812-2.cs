    var settings = new JsonSerializerSettings 
    { 
        PreserveReferencesHandling = PreserveReferencesHandling.Objects,  // Or PreserveReferencesHandling.All
        ContractResolver = ModifierContractResolver.Instance, 
    };
    var json = JsonConvert.SerializeObject(root, Formatting.Indented, settings);
