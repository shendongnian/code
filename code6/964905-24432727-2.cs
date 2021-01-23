    var obj = JsonConvert.DeserializeObject<Root>(json);
    public class Root
    {
        public string rootpath { set; get; }
        public Dictionary<string, Item> frontends { set; get; }
    }
