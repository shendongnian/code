    public class CurrecyConversion
    {
        public Dictionary<string, CurrencyRate> From { set; get; }
        public string To { set; get; }
        public DateTime RequestedDate { set; get; }
    }
    
    public class CurrencyRate
    {
        public decimal Rate { set; get; }
        public DateTime AsAtDate { set; get; }
    }
