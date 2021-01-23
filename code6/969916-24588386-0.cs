    string json = @"{ ""payload"": { ""one"": { ""x"":1 }, ""two"": { ""x"":2 }, ""three"": { ""x"":3 } } }";
    var  root = JsonConvert.DeserializeObject<RootObject>(json);
---
    public class Item
    {
        public int x { get; set; }
    }
    public class RootObject
    {
        public Dictionary<string,Item> payload { get; set; }
    }
