    public class Agent
    {
        private DateTime _createdDate;
        public DateTime Date
        {
            get { return _createdDate == default(DateTime) ? DateTime.Now : _createdDate; }
            set { _createdDate = value; }
        }
    }
