	public class SafeDateTimeConvertor : DateTimeConverterBase
	{
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			DateTime result;
			if (DateTime.TryParse(reader.Value.ToString(), out result))
				return result;
			return existingValue;
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(((DateTime)value).ToString("yyyy-MM-dd hh:mm:ss"));
		}
	}
