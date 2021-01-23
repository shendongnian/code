        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = authenticationService.AuthenticateUser(model.Login);
            IdentitySignIn(user.Id, user.Login);
            return RedirectToAction("Index", "Home");
        }
