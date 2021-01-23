	public string AppendAllModules(string json)
	{
		var obj = JObject.Parse(json);
		JToken token;
		if (obj.TryGetValue("allmodules", out token))
			return json;
			
		obj.Add(new JProperty("allmodules", new JObject(new JProperty("feature", "test-a"))));
		return obj.ToString();
	}
	
