    protected void bSignOut_Click(object sender, EventArgs e)
    {
      Button bSignOut = (Button)sender;
      if(bSignOut.CommandName.Equals("Regular"))
      {
            Session.Remove("User_Email");
            Session.RemoveAll();
            Response.Redirect("UserLogin.aspx");
      }
      else if(bSignOut.CommandName.Equals("Google"))
      {
            string script = "myIFrame.location='https://www.google.com/accounts/Logout'; startLogoutPolling();"
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "GoogleSignOut", script, true);
      }
      else if(bSignOut.CommandName.Equals("Facebook"))
      {
            FaceBookConnect.Logout(Request.QueryString["code"]);
      }
    }
