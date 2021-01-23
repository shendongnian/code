    public AccountController()
        : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())),
               new CustomerRepository())
    {
    }
