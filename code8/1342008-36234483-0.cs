    var authProperties = new AuthenticationProperties();
    var identity = new ClaimsIdentity("MyAuthenticationScheme");
	identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "1"));
    identity.AddClaim(new Claim(ClaimTypes.Name, "Admin"));
	var principal = new ClaimsPrincipal(identity);
    await HttpContext.Authentication.SignInAsync(
                "MyAuthenticationScheme", 
                claimsPrincipal, 
                authProperties);
    return RedirectToAction(nameof(HomeController.Index), "Home");
