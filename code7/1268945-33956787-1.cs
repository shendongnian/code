    public Buybest_Liberary.Data.UserManagement getUser(string email)
    {
        Buybest_Liberary.Data.UserManagement obj = new Buybest_Liberary.Data.UserManagement();
        // You should read the connection string from a config file 
        // don't specify it explicitly in code!
        string conString = ConfigurationManager.ConnectionStrings["-your-connection-string-name-here-"].ConnectionString;
    
        using (SqlConnection connection = new SqlConnection(conString))
        using (SqlCommand _cmd = new SqlCommand("getUserRecord", connection))
        {
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
    
            connection.Open();
            using (SqlDataReader dr = _cmd.ExecuteReader())
            { 
                // the SqlDataReader could return *multiple* rows - how are you
                // going to deal with that? Create an object for each row of data
                // and add them to a list to return? 
                while (dr.Read())
                {
                     obj.UId = Convert.ToInt32(dr[0]);
                     obj.Email = dr[1].ToString();
                     obj.Password = dr[2].ToString();
                }
                dr.Close();
            }
  
            connection.Close();
        }
    
        return obj;
    } 
