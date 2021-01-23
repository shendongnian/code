    public class ApplicationUser : IdentityUser
    {
        public virtual int EstablishmentID { get; set; }
        public virtual Establishment Establishment { get; set; }
    }
