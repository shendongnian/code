	private dynamic reconstructValueHolderFromJson(string json)
	{
		var o = JsonConvert.DeserializeObject<JObject>(json);
		var typeDescription = o.Properties().FirstOrDefault(p => p.Name == "ValueType");
		var type = System.Type.GetType(typeDescription.Value.ToString());
		return JsonConvert.DeserializeObject(json, typeof(ValueHolder<>).MakeGenericType(type));
	}
