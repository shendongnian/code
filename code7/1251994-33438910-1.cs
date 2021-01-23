    string password = txtConfirmPassword;
    var userName = Session["Username"];
    string myQuery = "UPDATE Users SET Password = @password Where Username = @username";
    using (SqlConnection connection = new SqlConnection("ConnectionString"))
    {
      using (SqlCommand cmd = new SqlCommand(myQuery, connection))
      {
         cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
         cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = userName;
         connection.Open();
         cmd.ExecuteNonQuery();
       }
    } //connection closed and disposed here
