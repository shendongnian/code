	[HttpPost]
	[AllowAnonymous]
	// The ASP.NET framework automatically puts a returnUrl query string parameter of the original
	// page the user requested. You just need to add that parameter here to gain access to it
	// (assuming you want to redirect the user back to the original requested page rather than 
	// some start page).
	public ActionResult Login(Login model, string returnUrl)
	{
		if (ModelState.IsValid)
		{
			if (System.Web.Security.Membership.ValidateUser(model.Nombre, model.Pass))
			{
				FormsAuthentication.SetAuthCookie(model.Nombre, model.Recordarme);
				
				// Redirect so the next request can see the user as authenticated
				if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
					&& !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
				{
					return Redirect(returnUrl);
				}
				else
				{
					return RedirectToAction("Index", "Home");
				}
			}
			ViewBag.Error = "Usuario y/o contraseña incorrectos.";
		}
		return View(model);
	}
