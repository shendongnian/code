    public class Payment
    {
    
        public int ID { get; set; }
            
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Compare("EmailAddress", ErrorMessage = "The email and confirmation email do not match.")]
    
        public string ConfrimEmailAddress { get; set; }
        [RegularExpression(@"([a-zA-Z0-9\s]+)", ErrorMessage = "Invalid Address")]
    
        public string Address { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string City { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Country { get; set; }
        [RegularExpression(@"\b\d{5}(?:-\d{4})?\b+", ErrorMessage = "Invalid postcode")]
        public string PostCode { get; set; }
    }
    public class PaymentDBContext : DbContext //controls information in database 
        {
            public DbSet<Payment> Payments { get; set; } //creates a donation database
        
            public System.Data.Entity.DbSet<CharitySite.Models.Charity> Charities { get; set; }
        }
