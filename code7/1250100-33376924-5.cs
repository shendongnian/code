    protected void btnLogIn_Click(object sender, EventArgs e) {
      string Username = txtUsername.Text;
      string Password = txtPassword.Text;
      try {
        if (ValidateUser(Username, Password)) {
            FormsAuthentication.RedirectFromLoginPage(Username, false);
        }
        else {
            lblMessage.Text = "Incorrect Credentials.";
            lblMessage.ForeColor = Color.Red;
        }
      }
      catch {
        lblMessage.Text = "Login Failed.";
        lblMessage.ForeColor = Color.Red;
      }
    }
