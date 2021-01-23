    public class Item
    {
        public string Key { get; set; }
        public string Data { get; set; }
    }
    var res = JsonConvert.DeserializeObject<List<Item>>(response));
