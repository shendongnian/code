    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrWhiteSpace(txtUser.Text) && !String.IsNullOrWhiteSpace(txtPass.Text))
        {
            browser.TextField("Username").Value = (txtUser.Text);
            browser.TextField("Password").Value = (txtPass.Text);
            var loginButton = browser.Div(Find.ById("signInButtonPanel"));
            loginButton.Links[0].Click(); // Try 0 or 1.
        }
    }
