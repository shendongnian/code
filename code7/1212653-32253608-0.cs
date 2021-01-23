	[JsonConverter(typeof(ResponseConverter))]
	public class Response
	{
		public Dictionary<string, string> Foo { get; set; }
	}
	
	public class ResponseConverter : JsonConverter
	{
		public override object ReadJson(
				JsonReader jsonReader, Type type, object obj, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	
		public override void WriteJson(
				JsonWriter jsonWriter, object obj, JsonSerializer serializer)
		{
			var response = (Response)obj;
			foreach (var kvp in response.Foo)
			{
				jsonWriter.WritePropertyName(kvp.Key);
				jsonWriter.WriteValue(kvp.Value);
			}
		}
		public override bool CanConvert(Type t)
		{
			return t == typeof(Response);
		}
	}
	
