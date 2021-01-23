    public class DataTableJsonConverter : JsonConverter
    {
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
    	public override object ReadJson(JsonReader r, Type t, object v, JsonSerializer s)
    	{
    		throw new NotImplementedException("Unnecessary: CanRead is false.");
    	}
    	public override bool CanRead { get { return false; } }
    	
        public override bool CanConvert(Type objectType)
    	{
    		return objectType == typeof(DataTable);
    	}
    }
