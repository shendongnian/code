    public class JqueryDatatablesConverter : JsonConverter
    {
    
    	public override bool CanConvert(Type objectType)
    	{
    		return typeof(DataTable).IsAssignableFrom(objectType);
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		dynamic dt = (DataTable)value;
    		dynamic count = dt.Columns.Count - 1;
    
    		writer.WriteStartObject();
    		writer.WritePropertyName("data");
    		writer.WriteStartArray();
    
    		foreach (DataRow dr in dt.Rows) {
    			writer.WriteStartArray();
    			for (int x = 0; x <= count; x++) {
    				serializer.Serialize(writer, dr[x]);
    			}
    			writer.WriteEndArray();
    		}
    
    		writer.WriteEndArray();
    		writer.WriteEndObject();
    
    	}
    }
