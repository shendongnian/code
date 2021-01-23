            public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
            {
                if (!await UserManager<>.IsEmailConfirmedAsync(user.Id))
                {
                    Session["ConfirmEmail"] = true;
                    RedirectToAction("ConfirmEmail");
                }
            }
