	public static string SerializeToMinimalJson(object obj)
	{
		var serializer = new JsonSerializer();
		serializer.NullValueHandling = NullValueHandling.Ignore;
		serializer.DefaultValueHandling = DefaultValueHandling.Ignore;
		return JToken.FromObject(obj, serializer).RemoveEmptyChildren().ToString();
	}
