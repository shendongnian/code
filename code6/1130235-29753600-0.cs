    using(SqlConnection con = new SqlConnection(connString))
    {
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = con;
      cmd.CommandText = "Insert into ..."
      con.Open();
      int rowsAffected = cmd.ExecuteNonQuery();
      MessageBox.Show("Rows affected: " + rowsAffected.ToString());
    }
    
