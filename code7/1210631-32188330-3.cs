    public class RGInventory
    {
        public string id { get; set; }
        public string classid { get; set; }
        public string instanceid { get; set; }
        public string amount { get; set; }
        public int pos { get; set; }
    }
    public class AppData
    {
        public string def_index { get; set; }
        public int is_itemset_name { get; set; }
    }
    public class Description
    {
        public string type { get; set; }
        public string value { get; set; }
        public string color { get; set; }
        public AppData app_data { get; set; }
    }
    public class Action
    {
        public string name { get; set; }
        public string link { get; set; }
    }
    public class MarketAction
    {
        public string name { get; set; }
        public string link { get; set; }
    }
    public class Tag
    {
        public string internal_name { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string category_name { get; set; }
        public string color { get; set; }
    }
    public class RGDescription
    {
        public string appid { get; set; }
        public string classid { get; set; }
        public string instanceid { get; set; }
        public string icon_url { get; set; }
        public string icon_url_large { get; set; }
        public string icon_drag_url { get; set; }
        public string name { get; set; }
        public string market_hash_name { get; set; }
        public string market_name { get; set; }
        public string name_color { get; set; }
        public string background_color { get; set; }
        public string type { get; set; }
        public int tradable { get; set; }
        public int marketable { get; set; }
        public int commodity { get; set; }
        public string market_tradable_restriction { get; set; }
        public List<Description> descriptions { get; set; }
        public List<Action> actions { get; set; }
        public List<MarketAction> market_actions { get; set; }
        public List<Tag> tags { get; set; }
    }
    public class RootObject
    {
        public bool success { get; set; }
        public bool more { get; set; }
        public bool more_start { get; set; }
        public Dictionary<string, RGInventory> rgInventory { get; set; }
        public Dictionary<string, RGDescription> rgDescriptions { get; set; }
    }
