	/// <summary>Converts a Json.Net JToken to a boxed conventional .NET type (int, List, etc.)</summary>
	/// <param name="token">The JToken to evaluate</param>
	public object JTokenToConventionalDotNetObject(JToken token)
	{
		switch(token.Type) {
			case JTokenType.Object:
				return ((JObject)token).Properties()
					.ToDictionary(prop => prop.Name, prop => JTokenToDotNetObject(prop.Value));
			case JTokenType.Array:
				return token.Values().Select(JTokenToDotNetObject).ToList();
			default:
				return token.ToObject(object);
		}
	}
