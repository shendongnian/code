    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JArray array = JArray.Load(reader);
        foreach (JToken item in array.ToList())
        {
            if (item.Type == JTokenType.Null)
                item.Remove();
        }
        return array.ToObject(objectType);
    }
