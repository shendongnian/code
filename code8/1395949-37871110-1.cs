	JsonConvert.DeserializeObject<MyObject>(myObjStr, new JsonSerializerSettings
	{
		Converters = new List<JsonConverter> { new JsonTypeMapper<IEntity, Entity>() }
                                                                //^^^^^^^, ^^^^^^
	}); 
