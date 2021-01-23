    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string sConnString = ConfigurationManager.ConnectionStrings["vhgroupconnection"].ConnectionString;
            using(OleDbConnection myCon = new OleDbConnection(sConnString))
            {
                 myCon.Open();
                 string userid = txtuserid.Text;
                 string oldpass = txtoldpass.Text;
                 string newPass = txtnewpass.Text;
                 string conPass = txtconfirmpass.Text;
                 string q = "select user_id,passwd from register where user_id = @userid and passwd = @oldpass";
                 OleDbCommand cmd = new OleDbCommand(q, myCon);
                 cmd.Parameters.AddWithValue("@userid", txtuserid.Text);
                 cmd.Parameters.AddWithValue("@oldpass", txtoldpass.Text);
                 string sUserId = string.Empty;
                 string sPass = string.Empty;
                 using(OleDbDataReader reader = cmd.ExecuteReader())
                 {
                    if(reader.HasRows)
                    {                            
                       reader.Read();
                       sUserId = reader["user_id"].ToString();
                       sPass = reader["passwd"].ToString();
                    }
                 }
                 if (sUserId != string.Empty && sPass != string.Empty)
                 {
                   if (newPass.Trim() != conPass.Trim())                   
                       lblmsg.Text = "New Password and old password does not match";
                   else
                   {
                        q = "UPDATE register SET passwd = @newPass WHERE user_id =@userid";
                        cmd = new OleDbCommand(q, myCon);
                        cmd.Parameters.AddWithValue("@newPasss", txtnewpass.Text);
                        cmd.Parameters.AddWithValue("@userod", txtuserid.Text);
                        cmd.Parameters.AddWithValue("@passwd", txtoldpass.Text);
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)                
                           lblmsg.Text = "Password changed successfully";                
                        else                
                           lblmsg.Text = "password not changed";
                 
                   }
                }
            }
        }
        catch (Exception ex)
          {
            throw ex;
          }
    }
