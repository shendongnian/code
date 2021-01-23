    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connStringName"].ConnectionString))
    using (SqlCommand cmd = new SqlCommand("SELECT * FROM user WHERE userName = username", connection))
    {
    connection.Open();
    SqlDataReader reader = cmd.ExecuteReader();
    if (reader.HasRows)
    {
      while (reader.Read())
      {
       string id = (string)reader["Id"].ToString();
       //work here
      }
    }
    connection.Close();
    }
