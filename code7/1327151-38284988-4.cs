        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
            {
                ViewData["ReturnUrl"] = returnUrl;
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser {
                        UserName = model.Email,
                        Email = model.Email,
                        FullName = model.FullName //<-ADDED PROPERTY HERE!!!
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        //ADD CLAIM HERE!!!!
                        await _userManager.AddClaimAsync(user, new Claim("FullName", user.FullName)); 
                        
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation(3, "User created a new account with password.");
                        return RedirectToLocal(returnUrl);
                    }
                    AddErrors(result);
                }
    
                return View(model);
            }
