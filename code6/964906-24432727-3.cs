    public class LnbConf
    {
    }
    public class Element
    {
        public bool enabled { get; set; }
        public int priority { get; set; }
        public List<object> networks { get; set; }
        public string lnb_type { get; set; }
        public string uuid { get; set; }
        public LnbConf lnb_conf { get; set; }
    }
    public class Satconf
    {
        public string type { get; set; }
        public int diseqc_repeats { get; set; }
        public bool lnb_poweroff { get; set; }
        public List<Element> elements { get; set; }
        public string uuid { get; set; }
    }
    public class Item
    {
        public bool powersave { get; set; }
        public bool enabled { get; set; }
        public int priority { get; set; }
        public string displayname { get; set; }
        public List<object> networks { get; set; }
        public string type { get; set; }
        public Satconf satconf { get; set; }
    }
