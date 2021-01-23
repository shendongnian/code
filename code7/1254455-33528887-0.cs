    public class ApplicationUser : IdentityUser
    {
        // Add this line
        // vvvvvvvvvvvvv
        public virtual ICollection<Advertisment> Advertisments { get; set; }
    }
