    string prefix = "prefix.";
    A obj = new A();
    StringWriter sw = new StringWriter();
    JsonTextWriter writer = new JsonTextWriter(sw);
    Type objType = obj.GetType();
    PropertyInfo[] objProperties = objType.GetProperties();
    writer.WriteStartObject();
    foreach (var property in objProperties)
    {
        Object value = property.GetValue(obj, null);
        writer.WritePropertyName(prefix + property.Name.ToLower());
        writer.WriteValue(value);
    }
    writer.WriteEndObject();
