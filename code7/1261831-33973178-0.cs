       protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        if (Roles.IsUserInRole(Login1.UserName, "Client"))
            Response.Redirect("~/TestONE.aspx");
        else if (Roles.IsUserInRole(Login1.UserName, "Technician"))
            Response.Redirect("~/TestTWO.aspx");
        
      
    }
