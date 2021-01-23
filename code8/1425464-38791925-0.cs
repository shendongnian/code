	public class Response {
		[JsonProperty("success")]
		public bool Success { get; set; }
		[JsonProperty("message")]
		public string Message { get; set; }
	}
	public class Response<T> : Response {
		[JsonProperty("data")]
		[JsonConverter(typeof(DataConverter))]
		public List<T> Data { get; set; }
	}
	public class DataConverter : JsonConverter {
		public override bool CanConvert(Type objectType) {
			return typeof(List<object>).IsAssignableFrom(objectType);
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			Dictionary<string, object> data = (Dictionary<string, object>)serializer.Deserialize(reader, typeof(Dictionary<string, object>));
			foreach (KeyValuePair<string, object> kvp in data) {
				if (kvp.Key != "total_count") {
					return ((JToken)kvp.Value).ToObject(objectType);
				}
			}
			return null;
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
			throw new NotImplementedException();
		}
	}
