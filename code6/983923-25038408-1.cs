	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		var jObj = JObject.Load(reader);
		var foo = jObj["MyFoo"];
		var result = new MyObject(); 
		result.FooType = jObj["FooType"].ToObject<SomeEnum>();
		switch (result.FooType)
		{
			case SomeEnum.Value1:
				result.MyFoo = foo.ToObject<FooType1>();
				break;
			case SomeEnum.Value2:
				result.MyFoo = foo.ToObject<FooType2>();
				break;
			case SomeEnum.Value3:
				result.MyFoo = foo.ToObject<FooType3>();
				break;
			default:
				throw new Exception("Unknown FooType");
		}
		return result;
	}
