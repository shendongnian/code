        [HttpPost]
        public async Task<ActionResult> ChangeEmail(string newEmail)
        {
            var user = await UserManager.FindByNameAsync(User.Identity.Name);
            user.Email = newEmail;
            UserManager.UpdateAsync(user);
            return View();
        }
