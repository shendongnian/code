	public class Item
	{
	   public string id { get; set;}
	   public string Color { get; set;}
	}
	public class Test
	{
		public ICollection<Item> Items { get; set; }
		public string AllColors()
		{
			return string.Join(",", Items.Select(i => i.Color));
		}
	}
