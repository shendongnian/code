    public class AccountProfile
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
    }
    
    public class AccountProfileViewModel
    {
        public AccountProfile Profile { get; set; }
    }
    
    public class AnotherViewModel
    {
        public AccountProfile Profile { get; set; }
        	
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
