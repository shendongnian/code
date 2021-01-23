    public AccountController
    {
        UserManager<ApplicationUser> _manager ;
        public AccountController()
            :this(new ApplicationDbContext()) //calls the other constructor with a default context
        {
        }
    
        public AccountController(ApplicationDbContext context)
        {
            this._manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context);
        }
    
    }
