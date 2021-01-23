    public class DataTableJsonConverter : JsonConverter
    {
    	private readonly Type[] _types;
    	public DataTableJsonConverter(params Type[] types)
    	{
    		_types = types;
    	}
    	public override void WriteJson(
    		JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		writer.WriteStartObject();
    		writer.WritePropertyName("data");
    		writer.WriteStartArray();
    		foreach(DataRow r in (value as DataTable).Rows)
    		{
    		    writer.WriteStartArray();
    			foreach(var c in r.ItemArray)
    			{
    				writer.WriteValue(c);
    			}
    		    writer.WriteEndArray();
    		}
    		writer.WriteEndArray();
    		writer.WriteEndObject();
    	}
    	public override object ReadJson(
    			JsonReader reader, Type objectType, 
    			object existingValue, JsonSerializer serializer)
    	{
    		throw new NotImplementedException("Unnecessary because CanRead is false.");
    	}
    	public override bool CanRead { get { return false; } }
    	public override bool CanConvert(Type objectType)
    	{
    		return _types.Any(t => t == objectType);
    	}
    }
