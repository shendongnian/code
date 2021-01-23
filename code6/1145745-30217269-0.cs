    public class State
    {
        [Key]
        public int StateId { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
    public class ApplicationUser : IdentityUser
    {
        //...
        [ForeignKey("State")]
        public int StateId { get; set; }
        public virtual State State { get; set; }
    }
