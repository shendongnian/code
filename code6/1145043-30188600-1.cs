    protected void btnLogin_Click(object sender, EventArgs e)
    {
        using (SqlConnection myDB = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString))
        {
            myDB.Open();
            string passwordObject = "select password from users where username = '" + txtUserName.Text + "'";
            using (SqlCommand com = new SqlCommand(passwordObject, myDB))
            {
                var res = com.ExecuteScalar();
                if (res != null)
                {
                    string checkPassWord = passwordObject as string;
                    if (txtPassword.Text == checkPassWord)
                    {
                        Session["New"] = txtUserName.Text;
                        Response.Redirect("EmpWelcome.aspx");
                    }
                    else
                    {
                        Response.Write("Incorrect details!  Please try again.");// if password is incorrect
                    }
                }
                else
                {
                    Response.Write("Incorrect details!  Please try again."); // if username is incorrect
                }
            }
        }
    }
