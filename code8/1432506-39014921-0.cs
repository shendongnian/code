    SqlConnection sqlcon = new SqlConnection(Functions.Auth());
            SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 1 password FROM dbo.Accounts WHERE login_name = '" + username_login.Text + "' and password='" + password_login.Text + "'", sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                this.Session["logged_in"] = "true";
                this.Session["username"] = text;
                base.Response.Redirect("/CP.aspx");
    
            }
            else
            {
                base.Response.Redirect("/error_page?err=login-fail");
            }
