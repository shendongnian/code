    void Main()
    {
        var json0 = @"{
        ""id"": 1234,
        ""person"": {
            ""name"": ""john"",
            ""surname"": ""doe""           
        }";
    	
    	var json1 = @"	{
        ""ref"": ""1234"",
        ""firstName"": ""JOHN"",
        ""lastName"": ""DOE""
    	}";
    	
    	foreach (var j in new []{json0, json1})
    	{
    		var name = GetFirstInstance<string>(new [] {"person.name", "firstName", "name1"}, j);
    		var surname = GetFirstInstance<string> (new [] {"person.surname", "lastName", "name2"}, j);
    		
    		new {name, surname}.Dump();
    	}
    }
    
    public T GetFirstInstance<T>(string[] path, string json)
    {
        using (var stringReader = new StringReader(json))
        using (var jsonReader = new JsonTextReader(stringReader))
        {
            while (jsonReader.Read())
            {
                if (jsonReader.TokenType == JsonToken.PropertyName  && path.Contains((string)jsonReader.Path))
                {
                    jsonReader.Read();
    
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
            return default(T);
        }
    }
