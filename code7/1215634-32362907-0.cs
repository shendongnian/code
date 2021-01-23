    protected void CreateUser_Click(object sender, EventArgs e)
    {
        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
        var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
        IdentityResult result = manager.Create(user, Password.Text);
        if (result.Succeeded)
        {
            if (chk1.Checked)
            {
                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            } else 
                Response.Write("Sorry");
    
        }
        else 
        {
            ErrorMessage.Text = result.Errors.FirstOrDefault();
        }
    }
