    // POST: Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(ApplicationUser editedUser)
		{
			if (ModelState.IsValid)
			{
				ApplicationUser userforEdit = await _userManager.FindByIdAsync(editedUser.Id.ToString());
				userforEdit.UserFirstName = editedUser.UserFirstName;
				userforEdit.UserLastName = editedUser.UserLastName;
				userforEdit.UserName = editedUser.UserName;
				userforEdit.Email = editedUser.Email;
				var UpdateUserResult = await _userManager.UpdateAsync(userforEdit);
				return RedirectToAction("Index");
			}
			return View(editedUser);
		}
