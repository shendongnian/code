    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public override IQueryable<ApplicationUser> Users
        {
            get
            {
                return base.Users.Include(x=>x.Personnel);//include what you want here
            }
        }
        //Rest of the original code
    }
