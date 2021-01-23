    public override object ReadJson(
        JsonReader reader,
        Type objectType, 
        object existingValue, 
        JsonSerializer serializer)
    {
		MyCustomType myCustomType = new MyCustomType();//for null values		
				
		if (reader.TokenType != JsonToken.Null)
		{			
			if (reader.TokenType == JsonToken.StartArray)
			{
				JToken token = JToken.Load(reader);	
				List<string> items = token.ToObject<List<string>>();  
				myCustomType = new MyCustomType(items);
			}
			else
			{
				JValue jValue = new JValue(reader.Value);
				switch (reader.TokenType)
				{
					case JsonToken.String:
						myCustomType = new MyCustomType((string)jValue);
						break;
					case JsonToken.Date:
						myCustomType = new MyCustomType((DateTime)jValue);
						break;
					case JsonToken.Boolean:
						myCustomType = new MyCustomType((bool)jValue);
						break;
					case JsonToken.Integer:
						int i = (int)jValue;
						myCustomType = new MyCustomType(i);
						break;
					default:
						Console.WriteLine("Default case");
						Console.WriteLine(reader.TokenType.ToString());
						break;
				}
			}
		}      
        return myCustomType;
    }
