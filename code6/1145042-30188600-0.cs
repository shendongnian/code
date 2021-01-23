    protected void btnLogin_Click(object sender, EventArgs e)
    {
        using (SqlConnection myDB = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString))
        {
            myDB.Open();
            string checkUser = "select count (*) from users where username = '" + txtUserName.Text + "'";
            using (SqlCommand com = new SqlCommand(checkUser, myDB))
            {
                var res = com.ExecuteScalar();
                if (res != null)
                {
                    int temp = Convert.ToInt32(res.ToString());
                    myDB.Close();
    
                    if (temp == 1)
                    {
                        myDB.Open();
                        string checkPassWord = "select password from users where password = '" + txtPassword.Text + "'";
                        SqlCommand passCom = new SqlCommand(checkPassWord, myDB);
                        string pass = passCom.ExecuteScalar().ToString().Replace(" ", "");
                        if (pass == txtPassword.Text)
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
    }
