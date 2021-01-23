    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
		JArray array = JArray.Load(reader);
		foreach (JToken item in array.ToList())
		{
			if (item.Type == JTokenType.Null)
				item.Remove();
		}
		object list = Activator.CreateInstance(objectType);
		serializer.Populate(array.CreateReader(), list);
		return list;
    }
