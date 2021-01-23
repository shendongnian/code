    public class ApplicationManager : ApplicationUser
    {
        public virtual List<ApplicationUser> Users { get; set; }
    
        public ApplicationManager()
        {
            Users = new List<ApplicationUser>();
        }
    }
    public class ApplicationUser : IdentityUser
    {
        public virtual ApplicationManager Manager { get; set; }
        ...           
    }
