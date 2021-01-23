    public class TestClassArrayConverter : JsonConverter 
    {
    	public override bool CanConvert(Type objectType)
    	{
    		return (objectType == typeof(TestClass[]));
    	}
    	
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		JArray table = JArray.Load(reader);
    		TestClass[] items = new TestClass[table.Count - 1];
    		for (int i = 1; i < table.Count; i++)
    		{
    			JArray row = (JArray)table[i];
    			items[i - 1] = new TestClass
    			{
    				AGE = (string)row[0],
    				POP = (string)row[1],
    				SEX = (string)row[2],
    				DATE = (string)row[3],
    				us = (string)row[4]
    			};
    		}
    		return items;
    	}
    	
    	public override bool CanWrite
    	{
    		get { return false; }
    	}
    	
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    }
