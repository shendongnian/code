    public class StringToJsonConverter : JsonConverter
    {
    	public override bool CanConvert(Type t)
    	{
    		throw new NotImplementedException();
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		var o = JsonConvert.DeserializeObject(value.ToString());
    		serializer.Serialize(writer,o);
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		var o = serializer.Deserialize(reader);
    		return JsonConvert.SerializeObject(o);
    	}
    }
