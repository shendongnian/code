    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FormattedName { get { return LastName + ", " + FirstName; } }
    }
