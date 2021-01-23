    [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> ChangeEmail(ChangeEmailViewModel model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                 //Get the user's Id
                var userId = User.Identity.GetUserId(); 
                //get the user (you can modify the variables to fit yours) 
               var user = UserManager.FindByIdAsync(userId);
    
              //this is how to change the Email
              user.Result.Email= model.Email// **EDIT**;
    
             userManager.UpdateAync(user.Result);
    
                return RedirectToAction("Index", new { Message = ManageMessageId.EmailChangedSuccess });
            }
