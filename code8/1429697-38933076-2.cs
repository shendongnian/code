    if (!ModelState.IsValid)
    {
        var roles = _context.Roles.Select(r => r.Name);
        model.RolesList = new SelectList(roles);
        return View(model);
    }
    .... // save and redirect
