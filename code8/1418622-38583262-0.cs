    public virtual async Task<ActionResult> Edit(PeopleUser user, string role)
    {
        if (ModelState.IsValid)
        { 
            var oldUser = await _userManager.FindByIdAsync(user.Id); // Note the await keyword.
            var oldRoleId = oldUser.Roles.SingleOrDefault().RoleId;
            var oldRoleName = _db.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;
    
            if (oldRoleName != role)
            {
                await _userManager.RemoveFromRoleAsync(user, oldRoleName);
                await _userManager.AddToRoleAsync(user, role);
            }
            _db.Entry(user).State = EntityState.Modified;
    
            return RedirectToAction("Index", "Home");
        }
        return View(user);
    }
