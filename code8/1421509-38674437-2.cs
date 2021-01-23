	var root = (JContainer)JToken.Parse(json);
	var query = root.Descendants()
		.Where(jt => (jt.Type == JTokenType.Object) || (jt.Type == JTokenType.Array))
		.Select(jo =>
			{
				if (jo is JObject)
				{
					if (jo.Parent != null && jo.Parent.Type == JTokenType.Array)
						return null;
					// No help needed in this section				
					// populate and return a JObject for the List<JObject> result 
					// next line appears for compilation purposes only--I actually want a populated JObject to be returned
					return new JObject();
				}
	
				if (jo is JArray)
				{
					var items = jo.Children<JObject>().SelectMany(o => o.Properties()).Where(p => p.Value.Type == JTokenType.String);
					return new JObject(items);
				}
				return null;
			})
		.Where(jo => jo != null)
		.ToList();
