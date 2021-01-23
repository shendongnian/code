    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //navigation prop, these are the CrossRates where this Currency was used as a From
        public virtual ICollection<CrossRate> FromCrossRates { get; set; }
     
        //navigation prop, these are the CrossRates where this Currency was used as a To
        public virtual ICollection<CrossRate> ToCrossRates { get; set; }
    }
    public class CrossRate
    {
        public int FromCurrencyId { get; set; }
        public int ToCurrencyId { get; set; }
        public DateTime Date { get; set; }
        public decimal Rate { get; set; }
        public Currency FromCurrency { get; set; }
        public Currency ToCurrency { get; set; }
    }
