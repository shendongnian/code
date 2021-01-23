    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
            if (Session["Username"] == null)
            {
                 //User is not logged-in. Display message or handle
                 return;
            }
            SqlDataReader dr = null;
            connectionString = ConfigurationManager.ConnectionStrings["LeaveManagementCS"].ConnectionString;
            conn = new SqlConnection(connectionString);
            string sql = "UPDATE Staff Set Password=@NewPwd Where UserName = @UserName";
           
            string newPwd = tbNewPassword.Text;
            try
            {
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NewPwd", tbNewPassword.Text);
                cmd.Parameters.AddWithValue("@UserName", Session["Username"].ToString());
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if ((tbNewPassword.Text == dr["newPwd"].ToString()))
                    {
                    }
                }
                dr.Close();
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
            catch (Exception ex)
            {
                lblOutput.Text = "Error Message: " + ex.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
    }
