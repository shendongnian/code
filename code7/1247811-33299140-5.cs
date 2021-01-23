    using (SqlConnection connection = new SqlConnection(connectionString))
    {
       using (SqlCommand cmd = new SqlCommand(myQuery, connection))
       {
         cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserNameTextBox.Text;
         cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = PasswordTextBox.Text;
         connection.Open();
         cmd.ExecuteNonQuery();
       }
    }
