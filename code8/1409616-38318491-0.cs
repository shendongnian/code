    string connectionString = ConfigurationManager.ConnectionStrings["LeaveManagementCS"].ConnectionString;
    if (Session["Username"] != null)
    {
        string sql = "UPDATE Staff Set Password=@NewPwd  WHERE UserName=@Username";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@NewPwd", tbNewPassword.Text);
                cmd.Parameters.AddWithValue("@Username", Session["Username"]);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    lblOutput.ForeColor = System.Drawing.Color.Green;
                    lblOutput.Text = "Password has been changed successfully";
                }
                else
                {
                    lblOutput.ForeColor = System.Drawing.Color.Red;
                    lblOutput.Text = "Password does not match with our database records.";
                }
            }
        }
    }
    else
    { 
      // Show message that Session is Empty Can't Proceed
    }
