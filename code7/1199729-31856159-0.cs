    protected void LogIn(object sender, EventArgs e)
    {
        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
        var user = manager.FindByName(username.Text);
        if (IsValid)
        {
            if (user != null)
            {
                var result = signinManager.PasswordSignIn(username.Text, Password.Text, RememberMe.Checked, shouldLockout: true);
                
                // If username and password is correct check if account is activated.
                if(!user.EmailConfirmed && result == SignInStatus.Success)
                {
                    FailureText.Text = "Invalid login attempt. You must have a confirmed email account.";
                    ErrorMessage.Visible = true;
                    return;
                }        
                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], 
                                                               Response);
                        break;
                    case SignInStatus.LockedOut:
                        //Response.Redirect("/Account/Lockout");    
                        FailureText.Text = "This account has been locked out, please try again later.";
                        ErrorMessage.Visible = true;
                        return;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                                        true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;    
                }                
            }    
            else
            {
                FailureText.Text = "Account not found.";
                ErrorMessage.Visible = true;
            }
        }
    }
