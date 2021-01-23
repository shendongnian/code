    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ChangePassword(ProfileViewModel model) {
        //get current user and update
        var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
    
        var updateResult = await UserManager.UpdateAsync(user);
        if (updateResult.Succeeded) {
            //do something and return
        }
        //failed - do something else and return
    }
