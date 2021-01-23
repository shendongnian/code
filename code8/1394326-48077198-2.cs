    var appUser = new ApplicationUser
    {
    	Id = 1,
    	UserName = viewModel.UserName,
    	Email = viewModel.UserName,
        SecurityStamp = Guid.NewGuid().ToString()
    };
    try
    {
    	var userPrincipal = await _signInManager.CreateUserPrincipalAsync(appUser);
    	foreach(var claim in userPrincipal.Claims)
    	{
    		appUser.Claims.Add(new ApplicationUserClaim { UserId = appUser.Id, ClaimType = claim.Type, ClaimValue = claim.Value });
    	}
    	await _signInManager.SignInAsync(appUser, viewModel.RememberMe);
    	return RedirectToLocal(returnUrl);
    }
    catch (Exception ex)
    {
        // Log Exception
        ModelState.AddModelError(string.Empty, "Invalid login");
    	return View();
    }
