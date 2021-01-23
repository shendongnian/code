    [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(Models.AccountViewModel vm, string returnUrl)
        {
            //first make sure they filled in all mandatory fields
            if (ModelState.IsValid)
            {
                //try to find the user by the credentials they provided
                var user = await UserManager.FindAsync(vm.LoginModel.Username, vm.LoginModel.Password);
                //if user is null then they entered wrong credentials
                if (user != null)
                {
                    //if user has confirmed their email already
                    if (user.EmailConfirmed == true)
                    {
                        //attempt to sign in the user
                        await SignInAsync(user, vm.LoginModel.RememberMe);
                        //if the return url is empty then they clicked directly on login instead of trying to access
                        //an unauthorized area of the site which redirected them to the login.
                        if (!string.IsNullOrEmpty(returnUrl))
                            return RedirectToLocal(returnUrl);
                        
                        //returnUrl was empty so user went to log in first
                        else
                        {
                            //lets check and see which roles this user is in so we can direct him to the right page
                            var rolesForUser = UserManager.GetRoles(user.Id);
                            //users can be in multiple roles but the first role dictates what they see after they sign in
                            switch (rolesForUser.First())
                            {
                                case "Normal_User":
                                    return RedirectToAction("Feed", "Account");
                                default:
                                    //user is not in any roles send him to the default screen
                                    break;
                            }
                        }
                    }
                        //user has not confirmed their email address redirect to email confirmation
                    else
                    {
                        //resend confirmation
                        await SendConfirmationEmail(user.Id);
                        //redirect user to unconfirmed email account view
                        return RedirectToAction("UnconfirmedAccount", "Account", new { Email = user.Email, UserId = user.Id });
                    }
                   
                }
                else
                {
                    //add errors to the view letting the user know they entered wrong credentials. Code will fall through and return
                    //the view below with these errors
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            // If we got this far then validation failed
            return View(vm);
        }
