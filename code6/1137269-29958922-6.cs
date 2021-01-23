    public class DataTableJsonConverter : JsonConverter
    {
    	private readonly Type[] _types;
    	public DataTableJsonConverter(params Type[] types)
    	{
    		_types = types;
    	}
    	public override void WriteJson(JsonWriter w, object v, JsonSerializer s)
    	{
    		w.WriteStartObject();
    		w.WritePropertyName("data");
    		w.WriteStartArray();
    		foreach(DataRow r in (v as DataTable).Rows)
    		{
    		    w.WriteStartArray();
    			foreach(var c in r.ItemArray)
    			{
    				w.WriteValue(c);
    			}
    		    w.WriteEndArray();
    		}
    		w.WriteEndArray();
    		w.WriteEndObject();
    	}
    	public override object ReadJson(JsonReader r, Type type, object v, JsonSerializer s)
    	{
    		throw new NotImplementedException("Unnecessary because CanRead is false.");
    	}
    	public override bool CanRead { get { return false; } }
    	public override bool CanConvert(Type objectType)
    	{
    		return _types.Any(t => t == objectType);
    	}
    }
