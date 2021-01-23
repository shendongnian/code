          [HttpPost]
          public ActionResult ChangePassword(
                    AspNetUsersViewModel userView,
                    string userNewPassword){
                               UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
                               var result = userManager.ChangePassword(_User.Id, userNewPassword , userView.Password);
                               return RedirectToAction("Index", "ConfigUser");
                                          
                                         }
