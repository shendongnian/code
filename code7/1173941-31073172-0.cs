	public class ConverterContractResolver : DefaultContractResolver
	{
		protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
		{
			IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
			foreach(var property in properties.Where(p => p.PropertyName == "MyProperty"))
				property.Converter = new CustomConverter();
			return properties;
		}
	}
	
	
	public abstract class CustomConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return true;
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return new MyType();
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
