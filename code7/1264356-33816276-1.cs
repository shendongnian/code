    public class SharePrices
    {
        public DateTime theDate { get; set; }
        public decimal sharePrice { get; set; }
        
        public override string ToString()
        {
            return String.Format("The Date: {0}; Share Price: {1};", theDate, sharePrice);
        }
    }
