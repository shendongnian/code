    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    public class NodesConverter : JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		return objectType == typeof(Node[]);
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		var nodes = new List<Node>();
    		
    		foreach (JProperty property in serializer.Deserialize<JObject>(reader).Properties())
    		{
    			var node = property.Value.ToObject<Node>();
    			// parse names as node_number
    			node.node_number = int.Parse(property.Name);
    			nodes.Add(node);
    		}
    
    		return nodes.ToArray();
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    	}
    }
