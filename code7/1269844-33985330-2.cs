        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserUpdateViewModel userUpdateViewModel)
        {
            if (!ModelState.IsValid) return View(userUpdateViewModel);
            var user = _db.Users.First(u => u.UserName == userUpdateViewModel.UserName);
            Mapper.Map(userUpdateViewModel, user);  // move viewmodel to entity model
            await _db.SaveChangesAsync();
            return this.RedirectToAction(a => a.Index()).WithSuccess("User updated.");
        }
