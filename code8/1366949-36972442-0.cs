public NAConverter: JsonConverter
{
    public override bool CanConvert(Type t) { return t == typeof(string); }
    public override ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        ...
    }
}
Then, in ReadJson, you'll be able to ask the JsonReader if it's pointing at a string, and if that's "NA". If so, return null or zero or Double.IsNaN; otherwise, defer to the base. 
Then pass an instance to `JsonConvert.DeserializeObject()` or `JsonConvert.Deserialize<T>()`
