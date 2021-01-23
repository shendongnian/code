    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl) {
            model.allUsers = db.Users.ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var user = db.Users.Where(i => i.Pid == model.userid).Single();
            if (user != null) {
                model.Email = user.Email;
            }
            else
                return View(model);
    ....
    }
