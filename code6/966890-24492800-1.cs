    public class Item
	{
		public int ID { get; set; }
		public int TYPE { get; set; }
		public int APP_TAG { get; set; }
		public string alert { get; set; }
		public string sound { get; set; }
		public int badge { get; set; }
	}
---
    var items = JsonConvert.DeserializeObject<List<Item>>(json);
