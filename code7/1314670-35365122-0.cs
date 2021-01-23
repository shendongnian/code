    var userTicket = new System.Web.HttpContextWrapper(System.Web.HttpContext.Current).GetUmbracoAuthTicket();
    if (userTicket != null)
    {
        var currentUser = ApplicationContext.Current.Services.UserService.GetByUsername(userTicket.Name);
    }
