	public class ConcreteCollectionTypeConverter<TCollection, TItem, TBaseItem> : JsonConverter
		where TCollection : ICollection<TBaseItem>, new()
		where TItem : TBaseItem
	{
		public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer)
		{
			serializer.Serialize(writer, value);
		}
	
		public override object ReadJson(
            JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var collection = new TCollection();
			var items = serializer.Deserialize<IEnumerable<TItem>>(reader);
			
			foreach (var item in items)
			{
				collection.Add(item);
			}
			
			return collection;
		}
	
		public override bool CanConvert(Type objectType)
		{
			return typeof(ICollection<TBaseItem>).IsAssignableFrom(objectType);
		}
	}
	
	[DataContract]
	public class Health : IHealth
	{
		[DataMember(Name = "status")]
		public string Status { get; set; }
		[DataMember(Name = "alerts")]
		[JsonConverter(
            typeof(ConcreteCollectionTypeConverter<List<IAlert>, Alert, IAlert>))]
		public IList<IAlert> Alerts { get; set; }
	}
