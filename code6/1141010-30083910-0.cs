    public class BusinessUnit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Currency Currency { get; set; }
        public string CurrencyCode { get { return Currency.Code; } }
    }
    public class Currency
    {
        public string Code { get; set; }
    }
