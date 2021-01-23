    public CustomJsonSerializer()
    {
        Converters.Add(new StringEnumConverter());
        ContractResolver = new CamelCasePropertyNamesContractResolver();
    }
