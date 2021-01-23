    public class JsonTypeMapper<TFromType, TToType> : JsonConverter
    {
    	public override bool CanConvert(Type objectType) => objectType == typeof(TFromType);
    
    	public override object ReadJson(JsonReader reader,
    	 Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		return serializer.Deserialize<TToType>(reader);
    	}
    
    	public override void WriteJson(JsonWriter writer,
    		object value, JsonSerializer serializer)
    	{
    		serializer.Serialize(writer, value);
    	}
    }
