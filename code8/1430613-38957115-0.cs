	public class Persons
	{
		public List<String> ListPers { get; set; }
	}
	public class JsonObjectsToPersonsConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return (objectType == typeof(Persons));
		}
		
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			Persons value = new Persons();
			JToken jtoken = JToken.Load(reader);
			JObject jObjectCast = jtoken.Value<JObject>();
	
			List<String> listPers = (from prop in jObjectCast.Properties()
									 select prop.Name).ToList();
			return new Persons { ListPers = listPers};
		}
	
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
