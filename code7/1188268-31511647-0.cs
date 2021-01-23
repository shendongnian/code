    public class MyObjectJsonConverter : JsonConverter
    {
    	public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		// Create an instance of proxy class, copy values from the
            // instance of MyObject class, write JSON from the proxy class.
    	}
    	
    	public override object ReadJson(
            JsonReader reader, Type type, object existingValue, JsonSerializer serializer)
    	{
    		// Deserialize proxy class, create an instance of MyObject class,
            // copy properties from the deserialized proxy class.
    	}
    	
    	public override bool CanConvert(Type objectType)
    	{
    		return typeof(MyObject).IsAssignableFrom(objectType);
    	}
    }
