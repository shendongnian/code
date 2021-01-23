        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
                {
                    if (!ModelState.IsValid) { return View(model); }
      
                    var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
                    switch (result)
                    {
                        case SignInStatus.Success:
    
                            // Transform here
                            var freshClaims = new List<Claim>
                            {
                               new Claim(ClaimTypes.Email, model.Email),
                               new Claim(ClaimTypes.Locality, "Earth (Milky Way)"),
                               new Claim(ClaimTypes.Role, "Trooper"),
                               new Claim(ClaimTypes.SerialNumber, "555666777")
                            };
                            AuthenticationManager.AuthenticationResponseGrant.Identity.AddClaims(freshClaims);
                            return RedirectToLocal(returnUrl);
