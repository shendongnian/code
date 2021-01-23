    public class CustomerProfile 
    {
        public string Phone { get; set; }
        // other profile fields
    }
    public class Customer 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public bool IsExternalCustomer { get; set; }
        public CustomerProfile Profile { get; set; }
    }
