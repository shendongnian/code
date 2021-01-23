     public class Time
    {
        private DateTime _date = DateTime.Now;
        public int ID { get; set; }
        public DateTime DateCreated
        {
            get { return _date; }
            set { _date = value; }
        }
    }
