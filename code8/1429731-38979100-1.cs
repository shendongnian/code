        [Authorize(Roles = "Admin")]
            public async Task<ActionResult> CreateVendor()
            {
                
                return View();
            }
             [Authorize(Roles = "Admin")]
               [HttpPost]
     public async Task<ActionResult> Vendor(VendorViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
             //Add Vendor role to user
               var role = await UserManager.AddToRolesAsync(user.Id, "Vendor");
     }
                    AddErrors(result);
                }
    
                // If we got this far, something failed, redisplay form
                return View(model);
            }
