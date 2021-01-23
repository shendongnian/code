    public ApplicationUserManager UserManager
    {
        get
        {
            return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        set
        {
            _userManager = value;
        }
    }
