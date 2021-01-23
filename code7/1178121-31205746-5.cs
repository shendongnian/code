    public sealed class SpecialJsonConverter : JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		return true;
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		var reader = new JsonTextReader(new StringReader(value.ToString()));
    		writer.WriteToken(reader);
    	}
    }
