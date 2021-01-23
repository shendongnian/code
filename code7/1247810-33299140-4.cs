    using (SqlConnection connection = new SqlConnection(connectionString))
    {
       using (SqlCommand cmd = new SqlCommand(myQuery, connection))
       {
         cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserNameTextBox.Text;
         cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = PasswordTextBox.Text;
         connection.Open();
         cmd.ExecuteNonQuery();
       }
    }
