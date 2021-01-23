	[JsonObject(MemberSerialization.OptIn)]
	public class ItemRecords : Collection<ItemRecord>  
	{  
		[JsonProperty("property1")]
		public int Property1 { get; set; }  
	
		[JsonProperty("property2")]
		public int Property2 { get; set; }  
		
		[JsonProperty("item_record")]
		IList<ItemRecord> ItemRecordList
		{
			get 
			{
				return Items;
			}
		}
	}
