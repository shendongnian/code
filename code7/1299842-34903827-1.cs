    var json = JsonConvert.SerializeObject(
        new Foo(),
        Formatting.Indented,
        new JsonSerializerSettings()
        {
            ContractResolver = new IgnoreEmptyEnumerablesResolver(),
            NullValueHandling = NullValueHandling.Ignore
        });
