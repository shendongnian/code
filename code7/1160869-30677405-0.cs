    public class ValueAddsConverter : JsonConverter
    {
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		var valueAdds = new ValueAdds();
    		var jo = (JObject)JObject.Load(reader)["ValueAdds"];
    
    		valueAdds.Size = Int32.Parse((string)jo["@size"]);
    
    		if (valueAdds.Size > 1)
    		{
    			valueAdds.ValueAdd = jo["ValueAdd"].Children().Select(x => x.ToObject<ValueAdd>());
    		}
    		else
    		{
    			valueAdds.ValueAdd = new List<ValueAdd>{jo["ValueAdd"].ToObject<ValueAdd>()};
    		}
    
    		return valueAdds;
    	}
    
    	public override bool CanConvert(Type objectType)
    	{
    		return (objectType == typeof (ValueAdds));
    	}
    }
    
    public class ValueAdd
    {
    	[JsonProperty(PropertyName = "description")]
    	public string Description { get; set; }
    }
    
    [JsonConverter(typeof (ValueAddsConverter))]
    public class ValueAdds
    {
    	public int Size { get; set; }
    
    	public IEnumerable<ValueAdd> ValueAdd { get; set; }
    }
