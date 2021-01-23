    public sealed class MoreThanNullableConverter : Newtonsoft.Json.JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof (MoreThanNullable<>);
    	}
    	public override bool CanWrite { get { return false; } }
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		// your code here to return a new MoreThanNullable instance
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    }
