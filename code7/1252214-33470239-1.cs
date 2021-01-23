    [HttpPost]
    public async Task<ActionResult> Create(RegisterViewModel model, params string[] selectedRoles)
    {
        ....
        // if you need to return the view, then
        model.TeamsList = new SelectList(_db.Teams, "Name", "Name");
        return View(model);
    }
