    if (hasPassword)
    {
         if (ModelState.IsValid)
         {
              IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
              if (result.Succeeded)
              {
                   return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
              }
              else
              {
                   ModelState.AddModelError(string.Empty, "Whatever message do you want to say");
              }
         }
    }
