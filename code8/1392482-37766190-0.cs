            string checkuser = "select count(*) from UserData where UserName=@uname and activation != null";
            SqlCommand com = new SqlCommand(checkuser, conn);
            com.Parameters.Add("@uname", SqlDbType.VarChar).Value = UserName.Text.Trim();
            int temp = Convert.ToInt32(com.ExecuteScalar());
    
    if(temp > 0)
    {
      // do processing
    }
    else
    {
      // not activated ... throw alert
    }
