    public class ApplicationUser : IdentityUser
    {
        // other codes
        
        // Add your extra profile information 
        // By Adding NotMapped attribute EF omits this and not puts in Identity's table
        [NotMapped]
        public Profile Profile { get; set; }
    }
    public class Profile
    {
        public int ID { get; set; }
        public string ExtraData { get; set; }
        // other properties 
    }
