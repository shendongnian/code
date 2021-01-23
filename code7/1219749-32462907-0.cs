    [IgnoreFirst]
    [DelimitedRecord(",")]
    public class MyObject
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private DateTime _EventDate;
        public DateTime EventDate
        {
            get { return _EventDate; }
            set { _EventDate = value; }
        }
        private string _IPAddress;
        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }
    }
