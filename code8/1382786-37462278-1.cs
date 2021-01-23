    private Lazy<UserService> _userService;
        
    protected UserService UserService
    {
        get
        {
            return _userService.Value;
        }
    }
        
    public MyController(UserService service = null)
    {
         service = service ?? 
              Request.GetOwinContext().GetUserManager<UserService>();
    
         _userService = new Lazy<UserService>(service);
    }
