    protected void LogIn(object sender, EventArgs e)
    {
        if (IsValid)
        {
            // Validate the user password
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
        
            // assuming you have a text box named UserName
            var user=manager.FindByName(UserName.Text);
            // or for advanced scenarios you can write:
            // var user = manager.Users.FirstOrDefault(u => u.UserName == UserName.Text);
            if(user !=null)
            {
                if(manager.CheckPassword(user, Password.Text))
                {
                    signinManager.SignIn(user, false, RememberMe.Checked);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
            }
        }
        FailureText.Text = "Invalid login attempt";
        ErrorMessage.Visible = true;
    }
