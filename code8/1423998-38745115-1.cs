    public class SomeDynamicObject : DynamicObject
    {
    	public string Text { get; set; }
    	public DynamicObject DynamicProperty { get; set; }
    }
    
    public class CustomDynamicConverter : JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		return true;
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		if (reader.TokenType == JsonToken.Null)
    			return null;
    
    		JObject jObject = JObject.Load(reader);
    
    		var target = Activator.CreateInstance(objectType);
    
    		//Create a new reader for this jObject, and set all properties to match the original reader.
    		JsonReader jObjectReader = jObject.CreateReader();
    		jObjectReader.Culture = reader.Culture;
    		jObjectReader.DateParseHandling = reader.DateParseHandling;
    		jObjectReader.DateTimeZoneHandling = reader.DateTimeZoneHandling;
    		jObjectReader.FloatParseHandling = reader.FloatParseHandling;
    
    		// Populate the object properties
    		serializer.Populate(jObjectReader, target);
    
    		return target;
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		var properties = value.GetType().GetProperties().Where(x => x.PropertyType != typeof(DynamicObject)).ToList();
    		JObject o = (JObject)JToken.FromObject(value);
    
    		properties.ForEach(x =>
    		{
    			o.AddFirst(new JProperty(x.Name, x.GetValue(value)));
    		});
    
    		o.WriteTo(writer);
    	}
    }
