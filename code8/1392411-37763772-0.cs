    public class Price
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }
    
    public class Stock
    {
        public string name { get; set; }
        public Price price { get; set; }
        public double percent_change { get; set; }
        public int volume { get; set; }
        public string symbol { get; set; }
    }
    
    public class StockDetails
    {
        public List<Stock> stock { get; set; }
        public string as_of { get; set; }
    }
