    protected void BtnCreate(object sender, EventArgs e)
    {
      SqlConnection connection = new SqlConnection(connectionString);
      connection.Open();
      SqlCommand idcommand = new SqlCommand("select max([personID]) from Person", connection)
      //id to new person
      int id = ((int)idcommand.ExecuteScalar()) + 1;
      //command
      string command = "INSERT INTO [Person] ([personID], [personName]) VALUES (@id, @name)";
      SqlCommand cmd = new SqlCommand(command, connection);
      cmd.Parameters.AddWithValue("@id", id++);//id increase
      cmd.Parameters.AddWithValue("@name", name.Text);
      cmd.ExecuteNonQuery();
      connection.Close();
    }
