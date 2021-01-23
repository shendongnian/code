    public class Customer
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
