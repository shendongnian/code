	public class DataTableJsonConverter : JsonConverter
	{
		private readonly Type[] _types;
		public DataTableJsonConverter(params Type[] types)
		{
			_types = types;
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteStartObject();
			writer.WritePropertyName("data");
			writer.WriteStartArray();
			
			var dt = value as DataTable;
			for(var i = 0; i < dt.Rows.Count; ++i)
			{
			    writer.WriteStartArray();
				for(var j = 0; j < dt.Columns.Count; ++j)
				{
					writer.WriteValue(dt.Rows[i][j]);
				}
			    writer.WriteEndArray();
			}
			
			writer.WriteEndArray();
			writer.WriteEndObject();
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
		}
		public override bool CanRead
		{
			get
			{
				return false;
			}
		}
		public override bool CanConvert(Type objectType)
		{
			return _types.Any(t => t == objectType);
		}
	}
