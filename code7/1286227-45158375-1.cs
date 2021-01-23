     protected void btnSignIn_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
          
            if (Membership.ValidateUser(userName, password))
            {
                Profile userInfo = dc.Profile.Where(s => s.UserName == userName).SingleOrDefault();
               AppSession.UserName = userInfo.UserName;
            }
       }
