    var obj = JsonConvert.DeserializeObject<Dictionary<int, AClass>>(JsonConvert);
    public class AClass
    {
        public string key { set; get; }
        public string key2 { set; get; }
    }
