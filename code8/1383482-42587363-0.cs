        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogOff()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            await _userManager.UpdateSecurityStampAsync(user.Id);
            return RedirectToAction("Index", "Home");
        }
