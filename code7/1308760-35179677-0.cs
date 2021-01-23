    public class Item
    {
      public int Value { get; set; }
    }
    public class BigObject
    {
      [JsonConverter(typeof(ArrayItemConverter))]
      public List<Item> Items;
    }
