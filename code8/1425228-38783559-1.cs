     [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> ChangeUserPassword(SetPasswordViewModel model,string userId)
        {
            if (ModelState.IsValid)
            {
                //var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                ApplicationUser appUser = db.Users.Find(userId);
                // await the result.
                var result = await UserManager.ChangePasswordAsync(appUser, model.NewPassword);
               if (result.Succeeded) // Or whatever you're expecting.
                {
                    var user =  UserManager.FindById(User.Identity.GetUserId());
                    //var user = db.Users.Find(userId);
                    if (user != null)
                    {
                        //await SignInManager<,>.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }
                    return RedirectToAction("Index", new { Message = ManageController.ManageMessageId.SetPasswordSuccess });
                }
                // AddErrors(result);
            }
    
            // If we got this far, something failed, redisplay form
            return View(model);
        }
}
