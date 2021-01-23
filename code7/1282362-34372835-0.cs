    protected override IList<JsonProperty> CreateProperties(Type type, Newtonsoft.Json.MemberSerialization memberSerialization)
    {
        IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization)
            .Where(p => _propertiesToSerialize.Contains(p.PropertyName)).ToList();
        
        foreach (JsonProperty prop in properties)
        {
            prop.Order = _propertiesToSerialize.IndexOf(prop.PropertyName) + 1;
        }
        return properties.OrderBy(p => p.Order).ToList();
    }
