     protected void signin_click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        HashData ob = new HashData();//Custom Class used for Hashing Passwords
        SqlCommand cmd = new SqlCommand("Logincheck", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = txt_username.Text.Trim();
        string pass = ob.Encrypt(txt_pass.Text.Trim());
        cmd.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = pass;
        SqlParameter result = new SqlParameter("@result", SqlDbType.Int) { Direction = ParameterDirection.Output };
        SqlParameter userrole = new SqlParameter("@userrole", SqlDbType.VarChar,50) { Direction = ParameterDirection.Output };
        cmd.Parameters.Add(result); cmd.Parameters.Add(userrole);
        cmd.ExecuteNonQuery();
        int rslt = Convert.ToInt32(result.Value);
        if (rslt == -1)
        {
            string message = "Login Failed";
            string url = "Login.aspx";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
        }
        string u_role = userrole.Value.ToString();
        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
            (1, txt_username.Text.Trim(), DateTime.Now,
            DateTime.Now.AddMinutes(30), false, u_role,
            FormsAuthentication.FormsCookiePath);
        string hash = FormsAuthentication.Encrypt(ticket);
        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
        
        if (ticket.IsPersistent)
        {
            cookie.Expires = ticket.Expiration;
        }
        Response.Cookies.Add(cookie);
       // Response.Redirect("Redirecting.aspx");
       
        if (u_role == "admin")
        {
            Response.Redirect("~/Admin/Admin.aspx");
        }
        if (u_role == "admin" || u_role == "manager")
        {
            Response.Redirect("~/Manager/Manager.aspx");
        }
        if (u_role == "teamlead" || u_role == "admin" || u_role == "manager")
        {
            Response.Redirect("~/Teamlead/Teamlead.aspx");
        }
        if (u_role == "qa")
        {
            Response.Redirect("Default.aspx");
        }
        cmd.Dispose();
        con.Close();
    }
