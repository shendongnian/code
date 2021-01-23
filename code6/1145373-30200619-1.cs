    public class Rootobject
	{
		public Arrayofitem ArrayofItem { get; set; }
	}
	public class Arrayofitem
	{
		public Item[] Item { get; set; }
	}
	public class Item
	{
		public string Amount { get; set; }
		public string Date { get; set; }
	}
