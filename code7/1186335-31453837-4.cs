    public ActionResult Index()
    {
         var roles = GetListOfRoles(); //Get all list of roles, for example from db
         var currentRoles = roles.Where(User.IsInRole);
         ....
    }
