    public class PriceList
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string CurrencySymbol { get; set; }
        public Status Status { get; set; }
        public Dictionary<string, decimal> Prices { get; set; }
    }
