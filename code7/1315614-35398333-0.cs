    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var wrapper = (Wrapper)value;
        var root = new JObject();
        var instance = JObject.FromObject(wrapper.Instance, new JsonSerializer
        {
            TypeNameHandling = TypeNameHandling.Objects
        });
        root.Add("Instance", instance);
        root.WriteTo(writer);
    }
