    public async Task<ActionResult> Register(RegisterViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = model.Email, Email = model.Email, IsEnabled = true };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
