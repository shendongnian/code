    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
    
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
    
        [Required]
        public bool Active { get; set; }
    }
