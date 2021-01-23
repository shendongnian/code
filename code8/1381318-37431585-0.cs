    protected void Button1_Click(object sender, EventArgs e)
        {
            string sqlupdate = null;
            string sqlCheckUser = null;
            string sqlCheck = null;
            string user = username.Text;
            string password = password_row.Text;
            if (user == String.Empty)
            {
                required.Text = "Please Enter Username";
                return;
            }
            else
            {
                try
                {
                    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    SqlCommand command;
                    SqlDataReader dataReader;
                    cnn.Open();
                    //NEVER EVER use raw input from the user in a SQL query, use parameters at all times to
                    //prevent SQL Injection
                    command = new SqlCommand("SELECT * FROM Users WHERE LoginID=@User", cnn);
                    command.Parameters.Add("@User",SqlDbType.NVarChar,100).Value = user;
                    dataReader = command.ExecuteReader();
                    if(dataReader.HasRows)
                    {
                        dataReader.Read();
                        string email = dataReader["Email"].ToString();
                        string userName = dataReader["LoginID"].ToString();
                        
                        TextBox1.Text = email;
                        required.Text = "Please Check your Email Address for New Password";
                        dataReader.Close(); //All data is fetched, Close the datareader in order to be able to run the update command
                        SqlCommand update = new SqlCommand("UPDATE Users SET Password=@Password WHERE LoginID=@User", cnn);
                        command.Parameters.Add("@Password",SqlDbType.NVarChar,255).Value = password;
                        command.Parameters.Add("@User",SqlDbType.NVarChar,100).Value = user;
                        command.ExecuteNonQuery();
                        required.Text = "Please Check your Email Address for New Password";
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("");
                        mail.From = new MailAddress("");
                        mail.To.Add(email);
                        mail.Subject = "FTP Password Reset";
                        mail.Body = "The Password for your FTP account has been reset. Your new password is the following:   " + password;
                        SmtpServer.Send(mail);
                    }
                    else
                    {
                        dataReader.Close();
                        //No user was found, do some fancy thing here!
                    }
                    command.Dispose();
                    cnn.Close();
                    cnn.Dispose();
                }
                catch (Exception ex)
                {
                    TextBox1.Text = Convert.ToString("Can not open connection ! ");
                }
            }
        }
