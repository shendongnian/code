    private void cmdLogin_ServerClick(object sender, System.EventArgs e)
    {
       if (ValidateUser(txtUserName.Value,txtUserPass.Value) )
       {
          FormsAuthenticationTicket tkt;
          string cookiestr;
          HttpCookie ck;
          tkt = new FormsAuthenticationTicket(1, txtUserName.Value, DateTime.Now, 
    DateTime.Now.AddMinutes(30), chkPersistCookie.Checked, "your custom data");
          cookiestr = FormsAuthentication.Encrypt(tkt);
          ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
          if (chkPersistCookie.Checked)
          ck.Expires=tkt.Expiration;	
    		    ck.Path = FormsAuthentication.FormsCookiePath; 
          Response.Cookies.Add(ck);
    
          string strRedirect;
          strRedirect = Request["ReturnUrl"];
          if (strRedirect==null)
                strRedirect = "default.aspx";
             Response.Redirect(strRedirect, true);
       }
       else
          Response.Redirect("logon.aspx", true);
    }
