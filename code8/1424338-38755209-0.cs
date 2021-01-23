    var json = @"{""id"": ""id1"",""name"": ""name1"",""type"": ""type1""}";
	var json2 = @"{""id"": ""id1"",""Name"": ""name1"",""type"": ""type1""}";
	JsonSerializerSettings settings = new JsonSerializerSettings()
	{
		ContractResolver = new CamelCasePropertyNamesContractResolver(),
		Converters = new List<JsonConverter> { new CamelCaseOnlyConverter() }
	};
	
	var response = JsonConvert.DeserializeObject<Response>(json, settings);
	var response2 = JsonConvert.DeserializeObject<Response>(json2, settings);
    public class CamelCaseOnlyConverter : JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		return true;
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, 
            object existingValue, JsonSerializer serializer)
    	{
    		if (reader.TokenType == JsonToken.Null)
    			return null;
    
    		var token = JToken.Load(reader);
    		
    		var isCamelCased = true;
    		foreach (JProperty x in token)
    		{
    			string nameFirstChar = x.Name[0].ToString();
    			if (nameFirstChar != nameFirstChar.ToLower())
    			{
    				isCamelCased = false;
    				break;
    			}
    		}
    		
    		if (!isCamelCased) return null;
    
    		return token.ToObject(objectType);
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, 
            JsonSerializer serializer)
    	{
    		JObject o = (JObject)JToken.FromObject(value);
    		o.WriteTo(writer);
    	}
    }
