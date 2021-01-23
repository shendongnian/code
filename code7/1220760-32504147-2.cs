    public class MyClassConverter : JsonConverter
    {
     
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        	throw new NotImplementedException();
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = new MyClass();
    		var jObj = JObject.Load(reader);
    		var stringsProp = jObj["MyStrings"];
    		if (stringsProp != null)
    		{
    			var strings = stringsProp.ToObject<List<string>>();
    			foreach (var s in strings)
    			{
    				obj.AddString(s);
    			}
    		}
    		return obj;
        }
    
        public override bool CanWrite
        {
            get { return false; }
        }
    
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MyClass);
        }
    }
