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
               var user = userManager.FindByIdAsync(userId);
    
              //this is how to change the Email
              user.Email= "the-new-email-add"// maybe ChangeEmailViewModel.Email;
    
             userManager.UpdateAync(user);
    
                return RedirectToAction("Index", new { Message = ManageMessageId.EmailChangedSuccess });
            }
