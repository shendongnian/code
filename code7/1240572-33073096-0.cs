      private void atag_ServerClick(object sender, System.EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
 
