    public class Charity
    {
        public int ID { get; set; }
        public string DisplayName { get; set; }
        public DateTime Date { get; set; }
        [Range(2, Int32.MaxValue, ErrorMessage = "The value must be greater than 2")]
        public Double Amount { get; set; }
        public Double TaxBonus { get; set; }
        public String Comment { get; set; }
    }
