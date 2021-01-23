    public class Entry
    {
        public string name { get; set; }
        public string stattrak { get; set; }
        public string star { get; set; }
        public string souvenir { get; set; }
        public string sort { get; set; }
        public string exterior { get; set; }
        public string quality { get; set; }
        public string icon { get; set; }
        public int worth { get; set; }
        public int betable { get; set; }
    }
    var schema = JsonConvert.DeserializeObject<Dictionary<string,Entry>>(schemaString);
