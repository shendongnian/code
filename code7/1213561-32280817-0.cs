    using (SqlConnection con = new SqlConnection("Data Source=NIFAL;Initial Catalog=LaundrySystem;Integrated Security=True;"))
    {
      string sql = "select entryDate from LaundrySystemTable where laundID=@id";
      var cmd = new SqlCommand( sql, con );
      cmd.Parameters.AddWithValue( "@id", textBox1.Text.Trim() ); // if its type is not string, then do the conversion here
      con.Open();
      SqlDataReader reader = cmd.ExecuteReader();
      if (reader.Read())
      {
        dateTimePicker1.Value = (DateTime?)reader["entryDate"];
      }
      con.Close();
    }
