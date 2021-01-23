    public class Testee {}
    public class Tester
    {
    	[JsonConverter(typeof(CustomMesssageConverter<Testee>), "Custom Error Message")]
    	public Testee Testee { get; set; }
    }
    
    public class CustomMesssageConverter<T> : JsonConverter where T : new()
    {
    	private string _customErrorMessage;
    	
    	public CustomMesssageConverter(string customErrorMessage)
    	{
    		_customErrorMessage = customErrorMessage;
    	}
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
           serializer.Serialize(writer, value);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                if (reader.TokenType == JsonToken.Null)
                	return null;
    
    			// Load JObject from stream
    			JObject jObject = JObject.Load(reader);
    	
    			// Create target object based on type
    			var target = new T();
    	
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
            catch(Exception ex)
            {
    			// log ex here
                throw new Exception(_customErrorMessage);
            }
        }
    
        public override bool CanConvert(Type objectType)
        {
           return typeof(T).IsAssignableFrom(objectType);
        }
    }
