            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // Added this section to automatically create account if we have an email address
                    if (!string.IsNullOrEmpty(loginInfo.Email))
                    {
                        var user = new ApplicationUser { UserName = loginInfo.Email, Email = loginInfo.Email };
                        var createUserResult = await UserManager.CreateAsync(user);
                        if (createUserResult.Succeeded)
                        {
                            var addLoginResult = await UserManager.AddLoginAsync(user.Id, loginInfo.Login);
                            if(addLoginResult.Succeeded)
                            {
                                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                                return RedirectToLocal(returnUrl);
                            }
                        }
                    }
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
