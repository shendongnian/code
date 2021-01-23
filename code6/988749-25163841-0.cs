       private async Task SignInAsync(ApplicationUser user, bool isPersistent)
		{
			AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
			var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
			
            // Add more custom claims here if you want. 
			var claims = new Collection<Claim>
			{
				new Claim("Surname",user.ApplicantName),
				new Claim("ApplicantId",user.ApplicantId),
				new Claim("AccessCodeId",user.AccessCodeId),
				new Claim ( "Registered", "YES")
			};
				   
			identity.AddClaims(claims);
			var principal = new ClaimsPrincipal(identity);
			// turn into Principal
			HttpContext.User = principal;
		
			AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
		}
