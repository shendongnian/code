	public static IObjectType ConvertJsonToClass<T>(string jsonString)
	{
		IObjectType obj = JsonConvert.DeserializeObject<T>(jsonString) as IObjectType;
		return obj;
	}
