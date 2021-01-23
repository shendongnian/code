     public static DataTable GetUserByUserName(string UserName)
    {
        DataTable DT = new DataTable();
        try
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["AMLiveConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("WebUsers_GetUsersByUserName", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", UserName);
            conn.Open();
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            Adapter.Fill(DT);
        }
        catch
        {
            throw;
        }
        finally{
            conn.Close();
            return DT;
        }
    }     
