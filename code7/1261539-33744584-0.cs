    void Main()
    {
	    var date = new DateTime(2015, 12, 25, 0, 0, 0, DateTimeKind.Local);
    	date.Kind.Dump();
	
    	using (var memoryStream = new MemoryStream())
    	{
    		Serialize(date, memoryStream);
    		memoryStream.Position = 0;
    		var deserializedDate = Deserialize<DateTime>(memoryStream);
    		deserializedDate.Kind.Dump();
    	}
    }
    // Define other methods and classes here
    public static void Serialize( object value, Stream s ) 
    {
        StreamWriter writer = new StreamWriter(s);
	
    	JsonTextWriter jsonWriter = new JsonTextWriter(writer);
	    JsonSerializer ser = new JsonSerializer();
    	ser.Serialize(jsonWriter, value);
	    writer.Flush();	    
    }
    
    public static T Deserialize<T>(Stream s) 
    {
    	T result;
        using (StreamReader reader = new StreamReader(s))
    	{
        	JsonTextReader jsonReader = new JsonTextReader(reader);
        	JsonSerializer ser = new JsonSerializer();
        	result = ser.Deserialize<T>(jsonReader);
    	}	
    	return result;
    }
