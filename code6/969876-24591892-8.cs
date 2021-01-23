	set {
		// get context of the authentication manager
		var authenticationManager = HttpContext.GetOwinContext().Authentication;
		// create a new identity from the old one
		var identity = new ClaimsIdentity(User.Identity);
		// update claim value
		identity.RemoveClaim(identity.FindFirst("AccountNo"));
		identity.AddClaim(new Claim("AccountNo", value));
		// tell the authentication manager to use this new identity
		authenticationManager.AuthenticationResponseGrant = 
			new AuthenticationResponseGrant(
				new ClaimsPrincipal(identity),
				new AuthenticationProperties { IsPersistent = true }
			);
	}
