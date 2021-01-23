    protected void CreateUser_Click(object sender, EventArgs e)
    {
        // ...
        // UserName and Email are both set to Email.text
        // Add a UserName TextBox and Replace UserName = Email.Text with UserName = UserName.Text
        var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
        // ...
    }
    protected void LogIn(object sender, EventArgs e)
    {
        if (IsValid)
        {
            // ...
            // The first argument is userName
            // Replace mail.Text with UserName.Text
            var result = signinManager.PasswordSignIn(mail.Text, Password.Text, RememberMe.Checked, shouldLockout: false);
            // ..
        }
    }
