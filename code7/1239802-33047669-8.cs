    public class UserStatistics
    {
        public string FullName { get; set; }
        public int Assigned { get; set; }    
        public int Resolved { get; set; }    
        public int Unresolved
        {
            get { return Assigned - Resolved; }
        }
    }
