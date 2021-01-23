	public class StationConverter : JsonConverter
	{
		public override object ReadJson(
            JsonReader r, Type t, object v, JsonSerializer s)
		{
			JObject jObject = JObject.Load(r);
			
			var prop = jObject.Property("nearbyStations");
			var wrapped = string.Format("[{0}]", prop.Value);
			JArray jsonArray = JArray.Parse(wrapped);
			prop.Value = jsonArray;
			
			var target = new Station();
			s.Populate(jObject.CreateReader(), target);
			
			return target;
		}
		public override void WriteJson(JsonWriter w, object v, JsonSerializer s)
		{
			throw new NotImplementedException("Unnecessary: CanWrite is false.");
		}
		public override bool CanWrite
		{
			get { return false; }
		}
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof (Station);
		}
	}
