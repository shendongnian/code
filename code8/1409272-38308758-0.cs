    var instance = Newtonsoft.Json.JsonConvert.DeserializeObject<Notification>(
        js,
        new ItemConverter());
    
    public class ItemA : Item { }
    public class ItemB : Item { }
    public class Item { }
    
    public class Notification
    {
    	public string timeAgo { get; set; }
    	public string time { get; set; }
    	public int alertId { get; set; }
    	public Item details { get; set; }
    	public int priority { get; set; }
    	public int type { get; set; }
    	public int isClosed { get; set; }
    	public int notesCount { get; set; }
    	public int patientAccountId { get; set; }
    	public int isRead { get; set; }
    }
    
    public class ItemConverter : JsonConverter
    {
    	private Type currentType;
    	public override bool CanConvert(Type objectType)
    	{
    		return typeof(Item).IsAssignableFrom(objectType) || objectType == typeof(Notification);
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		JObject item = JObject.Load(reader);
    		if (item["type"] != null)
    		{
                // save the type for later.
    			switch (item["type"].Value<int>())
    			{
    				case 1:
    					currentType = typeof(ItemA);
    					break;
    				default:
    					currentType = typeof(ItemB);
    					break;
    			}
    			return item.ToObject<Notification>();
    		}
    
            // use the last type you read to serialise.
    		return item.ToObject(currentType);
    	}
    
    	public override void WriteJson(JsonWriter writer,
    		object value, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    }
