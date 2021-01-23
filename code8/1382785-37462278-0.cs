    private UserService _userService;
    
    protected UserService UserService
    {
        get
        {
            return _userService;
        }
    }
    
    public MyController(UserService service = null)
    {
       this._userService = service ?? 
              Request.GetOwinContext().GetUserManager<UserService>();
    }
