    public class Item
    {
        public string fajr { get; set; }
        public string sunrise { get; set; }
        public string zuhr { get; set; }
        public string asr { get; set; }
        public string maghrib { get; set; }
        public string isha { get; set; }
    }
----
    var dict = JsonConvert.DeserializeObject<Dictionary<string, Item>>(json);
