    public async Task<ActionResult> Register(RegisterViewModel model)
            {
               
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser() { UserName = model.UserName , centerName = model.centerName };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await UserManager.AddToRoleAsync(user.Id, model.RoleName);
                        await SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
                // If we got this far, something failed, redisplay form
                var _context = new ApplicationDbContext();
                var roles = _context.Roles.ToList();
                model.RolesList = roles;
                return View(model);
                }
