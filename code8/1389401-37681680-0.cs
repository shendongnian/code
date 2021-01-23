    public class Items
    {
        public int id { get; set; }
        public string description { get; set; }
        public double unit_price { get; set; }
        public int quantity { get; set; }
    }
    public class rootClass
    {
        public int id { get; set; }
        public string customer { get; set; }
        public Items items { get; set; }
    }
