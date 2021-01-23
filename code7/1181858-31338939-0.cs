    public class Item
	{
		public int Number { get; set; }
		public string Headline { get; set; }
		public int Value { get; set; }
		public ItemType Type { get; set; }
	}
	public enum ItemType
	{
		value,
		order
	}
