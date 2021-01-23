    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return DeserializeDate(reader, objectType, existingValue, serializer, (ClaimsIdentity)Thread.CurrentPrincipal.Identity);
    }
    
    public object DeserializeDate(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer, ClaimsIdentity identity)
    {
        // do stuff...
    }
