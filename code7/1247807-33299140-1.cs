    using (SqlConnection connection = new SqlConnection("MyConnectionString"))
    {
       using (SqlCommand cmd = new SqlCommand("MyQuery", connection))
       {
         cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserNameTextBox.Text;
         cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = PasswordTextBox.Text;
       }
    }
