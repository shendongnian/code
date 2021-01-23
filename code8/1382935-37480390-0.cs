    private void DeleteUser(int userId)
    {
        string deleteCommandText = @"DELETE FROM MyUsers WHERE Id = @id";
        using(SqlConnection conn = new SqlConnection("your_connection_string_here"))
        {
            if(conn.ConnectionState != ConnectionState.Open) conn.Open();
            using(SqlCommand cmd = new SqlCommand())
            {
               cmd.Connection = conn;
               cmd.CommandText = deleteCommandText ;
               cmd.Parameters.AddWithValue("@Id", userId);
               
               int resultRowCount;
               resultRowCount = cmd.ExecuteNonQuery();
               if(resultRowCount <= 0)
                   throw new UserNotFoundException("Cannot delete User record, no record found");
            }
            if(conn.ConnectionState != ConnectionState.Closed) conn.Close();
        }
    }
