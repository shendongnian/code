	public static class JsonConvertEx
	{
		public static string SerializeObject<T>(T value)
		{
			StringBuilder sb = new StringBuilder(256);
			StringWriter sw = new StringWriter(sb, CultureInfo.InvariantCulture);
			
			var jsonSerializer = JsonSerializer.CreateDefault();
			using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
			{
				jsonWriter.Formatting = Formatting.Indented;
				jsonWriter.IndentChar = ' ';
				jsonWriter.Indentation = 4;
	
				jsonSerializer.Serialize(jsonWriter, value, typeof(T));
			}
	
			return sw.ToString();
		}
	}
	
