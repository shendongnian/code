	public class LocationConverter: JsonConverter
	{
		
		public override bool CanConvert(Type objectType)
		{
			return (objectType == typeof(Location));
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jo = JObject.Load(reader);
			Location location = jo.ToObject<Location>();
			Location.etc = jo.SelectToken("etc.etc").ToObject<type>();
            .
            .
            .
            return location;
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
