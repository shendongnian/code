     // create a new identity 
                var identity = new ClaimsIdentity(User.Identity);
                // Remove the existing claim value of current user from database
                if(identity.FindFirst("NameOfUser")!=null)
                    await UserManager.RemoveClaimAsync(applicationUser.Id, identity.FindFirst("NameOfUser"));
                // Update customized claim 
                await UserManager.AddClaimAsync(applicationUser.Id, new Claim("NameOfUser", applicationUser.Name));
                // the claim has been updates, We need to change the cookie value for getting the updated claim
                AuthenticationManager.SignOut(identity.AuthenticationType);
                await SignInManager.SignInAsync(Userprofile, isPersistent: false, rememberBrowser: false);
                return RedirectToAction("Index", "Home");
