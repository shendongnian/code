    public class Document : ICurrencyHolder
    {
        public int CurrencyId { get; set; }
        public int ExchangeRateId { get; set; }
    }
    
    public class ExtendedDocument : ICurrencyHolder
    {
        public DateTime SomeDate { get; set; }
        public int CurrencyId { get; set; }
        public int ExchangeRateId { get; set; }
    }
    public interface ICurrencyHolder
    {
        int CurrencyId { get; set; }
        int ExchangeRateId { get; set; }
    }
