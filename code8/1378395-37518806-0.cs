    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public ApplicationUserRole()
            : base()
        { }
        //this is important
        public virtual ApplicationRole Role { get; set; }
    }
