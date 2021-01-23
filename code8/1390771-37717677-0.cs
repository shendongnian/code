    public class Item
    {
        public string date_for { get; set; }
        public string fajr { get; set; }
        public string shurooq { get; set; }
        public string dhuhr { get; set; }
        public string asr { get; set; }
        public string maghrib { get; set; }
        public string isha { get; set; }
    }
    
    public class ItemContainer
    {
        public List<Item> Items { get; set; }
    }
