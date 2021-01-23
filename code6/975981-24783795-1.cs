    public class User : Entity
    {
        [EmailAddress]
        public string EmailAddress { get; set; }
    
        [Required]
        public string Name { get; set; }
    }
