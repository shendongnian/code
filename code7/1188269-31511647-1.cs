    public class MyObjectProxy
    {
    	public string s { get; set; }
    	public int i { get; set; }
    }
    public class MyObjectJsonConverter : JsonConverter
    {
    	public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		// Create an instance of MyObjectProxy, copy values from the
            // instance of MyObject, write JSON from the MyObjectProxy.
    	}
    	
    	public override object ReadJson(
            JsonReader reader, Type type, object value, JsonSerializer serializer)
    	{
    		// Deserialize MyObjectProxy, create an instance of MyObject,
            // copy properties from the deserialized MyObjectProxy.
    	}
    	
    	public override bool CanConvert(Type type)
    	{
    		return typeof(MyObject).IsAssignableFrom(type);
    	}
    }
