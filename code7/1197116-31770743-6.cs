	var jo = JsonConvert.DeserializeObject<JObject>(json);
	var typeDescription = jo.Properties().FirstOrDefault(p => p.Name == "ValueType");
	var type = System.Type.GetType(typeDescription.Value.ToString());
	var genericValueHolder = Activator.CreateInstance(typeof(ValueHolder<>).MakeGenericType(type));
	var genericValueHolderOfType = JsonConvert.DeserializeObject(json, genericValueHolder.GetType());
