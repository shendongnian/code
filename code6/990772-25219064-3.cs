    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ManagePublicSettings(ManagePublicSettingsViewModel model)
    
    ...
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ManageUser(ManageUserViewModel model)
