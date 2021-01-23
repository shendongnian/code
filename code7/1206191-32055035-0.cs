     private void Login_Click(Object sender, EventArgs e)
     {
         // Create a custom FormsAuthenticationTicket containing
         // application specific data for the user.
         string username     = UserNameTextBox.Text;
         string password     = UserPassTextBox.Text;
         bool   isPersistent = false;
        if (Membership.ValidateUser(username, password))
        {
        string userData = "ApplicationSpecific data for this user.";
        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
           username,
           DateTime.Now,
           DateTime.Now.AddMinutes(30),
           isPersistent,
           userData,
           FormsAuthentication.FormsCookiePath);
          // Encrypt the ticket.
         string encTicket = FormsAuthentication.Encrypt(ticket);
          // Create the cookie.
          Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
          // Redirect back to original URL.
          Response.Redirect(FormsAuthentication.GetRedirectUrl(username, isPersistent));
         }
         else
            {
           Msg.Text = "Login failed. Please check your user name and password and try again.";
            }
    }
