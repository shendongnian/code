    public class Task
    {
        [NotMapped] 
        public TimeSpan Duration
        {
            get { return Duration2 - DateTime.MinValue; }
            set { Duration2 = DateTime.MinValue + value; }
        }
     
        public DateTime Duration2 { get; set; }
    }
