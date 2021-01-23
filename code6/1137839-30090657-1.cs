    public class DailyPaymentTotalModel : ViewModelBase
    {
        public int Day 
        {
            get { return DateTimeStamp.Day; }
            set { DateTimeStamp  = new DateTime(1, 1, value, 0, 0, 0); } 
        }
        
        public DateTime DateTimeStamp { get; set; }
        public decimal Amount { get; set; }
        public int Count { get; set; }
    }
