	var userTicket = new HttpContextWrapper(HttpContext.Current).GetUmbracoAuthTicket();
	if (userTicket != null)
	{
		var currentUser = ApplicationContext.Services.UserService.GetByUsername(userTicket.Name);
		if (!currentUser.Groups.Any(x => x.Alias.Equals("admin")))
		{
            // Do something if the user is not an admin
			Response.Redirect("~/");
		}
	}
