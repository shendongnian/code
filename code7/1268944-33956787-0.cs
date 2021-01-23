    public Buybest_Liberary.Data.UserManagement getUser(string email)
    {
        Buybest_Liberary.Data.UserManagement obj = new Buybest_Liberary.Data.UserManagement();
        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahmadshair\Documents\Buybest.mdf;Integrated Security=True;Connect Timeout=30";
    
        using (SqlConnection connection = new SqlConnection(conString))
        using (SqlCommand _cmd = new SqlCommand("getUserRecord", connection))
        {
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
    
            connection.Open();
            using (SqlDataReader dr = _cmd.ExecuteReader())
            {
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
