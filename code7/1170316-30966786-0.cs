    // many to many
    public class Interest
    {
        public int InterestId { get; set; }
        public string InterestDesc { get; set; } // field can't match class name
    }
    // one to many
    public class Interest
    {
        public int UserId { get; set; }  // Make primary key the FK into application user
        public string InterestDesc { get; set; } // field can't match class name
    }
