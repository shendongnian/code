        {
            string firstname;
            ApplicationDbContext db = new ApplicationDbContext();
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);
            ApplicationUser user = userManager.FindByName(HttpContext.Current.User.Identity.Name);
            firstname = user.FirstName;                              
            
            return firstname;
        }
