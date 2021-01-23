    // GET: Edit
		[HttpGet]
		public async Task<IActionResult> Edit(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(404);
			}
			ApplicationUser userforEdit = await _userManager.FindByIdAsync(id.ToString());
			if (userforEdit == null)
			{
				return new HttpStatusCodeResult(404);
			}
			return View(userforEdit);
		}
