    public class ApplicationUser : IdentityUser
    {
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
