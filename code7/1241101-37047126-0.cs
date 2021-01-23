	public override void WriteJson(JsonWriter writer, object value,
		JsonSerializer serializer)
	{
		var properties = value.GetType().GetRuntimeProperties ().Where(p => p.CanRead && p.CanWrite);
		JObject main = new JObject ();
		foreach (PropertyInfo prop in properties) {
			JsonPropertyAttribute att = prop.GetCustomAttributes(true)
				.OfType<JsonPropertyAttribute>()
				.FirstOrDefault();
			string jsonPath = (att != null ? att.PropertyName : prop.Name);
			var nesting=jsonPath.Split(new[] { '.' });
			JObject lastLevel = main;
			for (int i = 0; i < nesting.Length; i++) {
				if (i == nesting.Length - 1) {
					lastLevel [nesting [i]] = new JValue(prop.GetValue (value));
				} else {
					if (lastLevel [nesting [i]] == null) {
						lastLevel [nesting [i]] = new JObject ();
					}
					lastLevel = (JObject)lastLevel [nesting [i]];
				}
			}
		}
		serializer.Serialize (writer, main);
	}
