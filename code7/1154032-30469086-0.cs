    OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=names.mdb";
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT ID,nickname FROM names ORDER BY rnd(ID)";
                foreach (Control control in Controls)
      {
        if (control is Label)
        {
          OleDbDataReader reader = command.ExecuteReader();
          reader.Read();
          control.Text = reader["nickname"].ToString();
          reader.Close();
        }
      }
                connection.Close();
