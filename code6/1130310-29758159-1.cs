    protected void _login_Click(object sender, EventArgs e)
    {
        using (var con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Testconnection"].ConnectionString))
        {
            Session["New"] = null;
            try
            {
                con.Open();
                var sqlText = String.Format("SELECT password FROM dbo.loginuser WHERE username='{0}';", Textusername.Text);
                var sqlResult = EmpPassword(sqlText, con);
                if (sqlResult == textpassword.Text)
                {
                    Session["New"] = Textusername.Text;
                    Response.Redirect("Reporthome.aspx");
                }
                else
                {
                    sqlText = String.Format("Select epass from dbo.employee where idno='{0}';", Textusername.Text);
                    sqlResult = EmpPassword(sqlText, con);
                    if (sqlResult == textpassword.Text)
                    {
                        Session["New"] = Textusername.Text;
                        Response.Redirect("Engineerhome.aspx");
                    }
                    else
                    {
                        Response.Write("password is incorrect");
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }
    }
