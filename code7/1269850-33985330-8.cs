        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserUpdateViewModel userUpdateViewModel)
        {
            if (!ModelState.IsValid) return View(userUpdateViewModel);
            var user = _db.Users.First(u => u.UserName == userUpdateViewModel.UserName);
            // Mapper.Map(userUpdateViewModel, user);  // move viewmodel to entity model
            // instead of automapper, you can do this:
            user.UserName = userUpdateViewModel.UserName;
            user.FirstName = userUpdateViewModel.FirstName;
            user.LastName = userUpdateViewModel.LastName;
            user.Email = userUpdateViewModel.Email;
            await _db.SaveChangesAsync();
            return this.RedirectToAction(a => a.Index()).WithSuccess("User updated.");
        }
