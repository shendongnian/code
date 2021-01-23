        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = UserRepo.CreateUser(model.Email, model.Password);
                if (!result.Succeeded)
                {
                     AddErrors(result);
                }
            }
        }
    
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                string errorMessage = error;
                if (error.EndsWith("is already taken."))
                    errorMessage = "Your error message";
                ModelState.AddModelError("", errorMessage);
            }
        }
