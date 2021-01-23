    private bool _IsAdminLoggedIn = false;
    
    var userTicket = new System.Web.HttpContextWrapper(System.Web.HttpContext.Current).GetUmbracoAuthTicket();
    if (userTicket != null)
    {
        var currentUser = ApplicationContext.Services.UserService.GetByUsername(userTicket.Name);
        if (!String.IsNullOrEmpty(currentUser.UserType.Alias) && currentUser.UserType.Alias == "admin")
        {
    	_IsAdminLoggedIn = true
    	}
    }
