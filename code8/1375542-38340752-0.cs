            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var authService = new AdAuthenticationService(authenticationManager);
            var authenticationResult = authService.SignIn(model.UserName, model.Password);
            if (authenticationResult.IsSuccess)
            {
                ModelState.AddModelError("", "AD Authenticated: " + model.UserName);
                // we are in
                // check to see if user exixts in AspNetUsers.  If not, add with default role.
                
                var inAsp = UserManager.Users.Any(x => x.UserName == model.UserName);
                if (!inAsp)
                {
                    ModelState.AddModelError("", "Did not find User: " + model.UserName);
                    var newUser = new ApplicationUser
                    {
                        UserName = model.UserName,
                        Email = model.UserName + "@a_company.com"
                    };
                    ModelState.AddModelError("", "Set new user " + model.UserName);
                    // Add the AD user as an Identity user so we can relate a role to AD Login.
                    var chkUser = UserManager.Create(newUser, model.Password);
                    ModelState.AddModelError("", "Created new user: " + model.UserName + " Error: " + string.Join("\n", chkUser.Errors.ToArray()));
                    //Add default User to Role Admin   
                    if (chkUser.Succeeded)
                    {
                        ModelState.AddModelError("", "Created Identity user: " + newUser.UserName);
                        var result1 = UserManager.AddToRole(newUser.Id, "PM");
                        if (result1.Succeeded)
                            ModelState.AddModelError("","Added PM role to user: " + newUser.UserName);
                    }
                }
            }
