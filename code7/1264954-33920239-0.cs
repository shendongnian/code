    protected void btnlogin_Click(object sender, System.EventArgs e)
    {
        char activation;
    
    	if (Request.QueryString["tokenNum"] != null)
        {
            using (OdbcConnection dbConnection = new OdbcConnection(srlsConnStr))
            {
                dbConnection.Open();
                {
                    OdbcCommand dbCommand = new OdbcCommand();
                    dbCommand.Connection = dbConnection;
                    dbCommand.CommandText = @"SELECT tokenNum FROM login WHERE useremail = ?";
                    dbCommand.Parameters.AddWithValue("@useremail", txtUsername.Text);
                    dbCommand.ExecuteNonQuery();
    
                    OdbcDataReader dataReader = dbCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (token == dataReader["tokenNum"].ToString())
                        {
                            updateActivationStatus(txtUsername.Text);
                            LoginWithPasswordHashFunction();
                        }
                        else
                        {                               
                            test.Text = "You are not authorized to login! Please activate your account following the activation link sent to your email " + txtUsername.Text + " !";
                        }
                    }
                }
                dbConnection.Close();
                }
            }
        else if (Request.QueryString["tokenNum"] == null)
        {
            using (OdbcConnection dbConnection = new OdbcConnection(srlsConnStr))
            {
                dbConnection.Open();
                {
                    OdbcCommand dbCommand1 = new OdbcCommand();
                    dbCommand1.Connection = dbConnection;
                    dbCommand1.CommandText = @"SELECT * FROM login WHERE useremail = ?;";
    
                    dbCommand1.Parameters.AddWithValue("@useremail", txtUsername.Text);
                    dbCommand1.ExecuteNonQuery();
    
                    OdbcDataReader dataReader1 = dbCommand1.ExecuteReader();
                    if (dataReader1.Read())
                    {
                        activation = Convert.ToChar(dataReader1["activation_status"]);
    							
                        if (activation == 'Y')
                        {                                
                            LoginWithPasswordHashFunction();
                        }
                        else
                        {
                            lblMessage.Text = "Please activate your account following the Activation link emailed to you at <i>" + txtUsername.Text + "</i> to Continue!";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Invalid Username or Password";
                    }
    
                    dataReader1.Close();
                }
                dbConnection.Close();
            }
        }
    }
    private void LoginWithPasswordHashFunction()
    {
        List<string> salthashList = null;
        List<string> usernameList = null;
    
        try
        {
            using (OdbcConnection dbConnection = new OdbcConnection(srlsConnStr))
            {
                dbConnection.Open();
                {
                    OdbcCommand dbCommand = new OdbcCommand();
                    dbCommand.Connection = dbConnection;
                    dbCommand.CommandText = @"SELECT slowhashsalt, useremail FROM login WHERE useremail = ?;";
    
                    dbCommand.Parameters.AddWithValue(@"useremail", txtUsername.Text);
                    OdbcDataReader dataReader = dbCommand.ExecuteReader();
                    while (dataReader.HasRows && dataReader.Read())
                    {
                  
                        if (salthashList == null)
                        {
                            salthashList = new List<string>();
                            usernameList = new List<string>();
                        }
                        string saltHashes = dataReader.GetString(dataReader.GetOrdinal("slowhashsalt"));
                        salthashList.Add(saltHashes);
    
                        string userInfo = dataReader.GetString(dataReader.GetOrdinal("useremail"));
    
                        usernameList.Add(userInfo);
                    }
    
                    dataReader.Close();
    
                    if (salthashList != null)
                    {
                               
                        for (int i = 0; i < salthashList.Count; i++)
                        {
                            bool validUser = PasswordHash.ValidatePassword(txtPassword.Text, salthashList[i]);
                            if (validUser == true)
                            {                                    
                                Session["useremail"] = usernameList[i];
                                        
                                OdbcCommand dbCommand1 = new OdbcCommand();
                                dbCommand1.Connection = dbConnection;
                                dbCommand1.CommandText = @"SELECT userstatus FROM login WHERE useremail = ?;";
    
                                dbCommand1.Parameters.AddWithValue("@useremail", txtUsername.Text);
                                dbCommand1.ExecuteNonQuery();
    
                                OdbcDataReader dataReader1 = dbCommand1.ExecuteReader();
                                while (dataReader1.Read())
                                {
                                    user_status = dataReader1["userstatus"].ToString();
                                    Session["userType"] = user_status;
                                }
    
                                Response.BufferOutput = true;
    
                                if (user_status == "Participant")
                                {
                                    Response.Redirect("/StudentUser", false);
                                }
                                else if (user_status == "Coordinator")
                                {
                                    Response.Redirect("/CoordinatorUser", false);
                                }
                                else if (user_status == "Instructor")
                                {
                                    Response.Redirect("/InstructorUser", false);
                                }
                                else if (user_status == "Coordinator/Instructor")
                                {
                                    Response.Redirect("/CoordinatorInstructorUser", false);
                                }
    
                                dataReader1.Close();
                                                                            
                                Response.Redirect(/StudentUser) - Goes to Login Page";
                            }
                            else
                            {
                                lblMessage.Text = "Invalid Username or Password! Please Try Again!";
                            }
                        }
                    }
                }
                dbConnection.Close();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void updateActivationStatus(string email)
    {
        using (OdbcConnection dbConnection = new OdbcConnection(srlsConnStr))
        {
            dbConnection.Open();
            {
                OdbcCommand dbCommand = new OdbcCommand();
                dbCommand.Connection = dbConnection;
                dbCommand.CommandText = @"UPDATE login set activation_status = 'Y' WHERE useremail = ?;";
    
                dbCommand.Parameters.AddWithValue("@useremail", txtUsername.Text);
                dbCommand.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
