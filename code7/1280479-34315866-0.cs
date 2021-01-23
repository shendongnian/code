    [JsonConverter(typeof(MyObjConverter))]
    public class MyObj{
      public double FirstDouble{ get; set; }
      public double SecondDouble { get; set; }
    }
    
    public class MyObjConverter : JsonConverter
    {
	  public override bool CanWrite { get { return false; } }
	
	  public override bool CanConvert(Type objectType) {
		return objectType == typeof(MyObj);		
	  }
	
	  public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {				
		var doubles = serializer.Deserialize<List<double>>(reader);
		return new MyObj { FirstDouble = doubles[0], SecondDouble = doubles[1] };						
	  }
	  public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
		throw new NotImplementedException();
	  }
    }
