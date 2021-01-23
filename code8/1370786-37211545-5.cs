    private ApplicationDbContext db = new ApplicationDbContext();
   
    public ProjectsController()
        : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
    {
        
    }
    public ProjectsController(UserManager<ApplicationUser> userManager)
    {
        UserManager = userManager;
    }
    public UserManager<ApplicationUser> UserManager { get; set; }
