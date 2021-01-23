    private void cmdLogin_ServerClick(object sender, System.EventArgs e)
    {
    if (ValidateUser(txtUserName.Value,txtUserPass.Value) )
    	FormsAuthentication.RedirectFromLoginPage(txtUserName.Value,
    		chkPersistCookie.Checked);
    	else
    		Response.Redirect("logon.aspx", true);
    }
    		
