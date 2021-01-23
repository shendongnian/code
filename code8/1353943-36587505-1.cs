    public class AnoConverter : JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		throw new NotImplementedException();
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		//This deserialize the Ano into a Dictionary,
    		//and returns the Key that contains the actual Year you want
    		
    		var ano  = serializer.Deserialize<Dictionary<string, object>>(reader);
    		
    		//I'm assuming that there will be always one year here.
    		return ano.FirstOrDefault().Key;
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    }
