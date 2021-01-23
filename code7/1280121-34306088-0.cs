    public class CustomJsonConverter : JsonConverter
    {
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
    		var list = (IList)value;
    		
    		JArray s = new JArray();
    
    		foreach (var item in list)
    		{
    			JToken token = JToken.FromObject(item);
    			JObject obj = new JObject();
    			
    			foreach (JProperty prop in token)
    			{
    				if (prop.Name != "Title") // your logic here
    					obj.Add(prop);
    			}
    			
    			s.Add(obj);
    		}
    
    		s.WriteTo(writer);
    		
    	}
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }
    
        public override bool CanRead
        {
            get { return false; }
        }
    
        public override bool CanConvert(Type objectType)
        {
            return objectType != typeof(IList);
        }
    }
