    //id to new person
    private static int id = -1;
    protected void BtnCreate(object sender, EventArgs e)
        {
          SqlConnection connection = new SqlConnection(connectionString);
    
          //command
          string command = "INSERT INTO [Person] ([personID], [personName]) VALUES (@id, @name)";
    
          SqlCommand cmd = new SqlCommand(command, connection);
          cmd.Parameters.AddWithValue("@id", id++);//id increase
          cmd.Parameters.AddWithValue("@name", name.Text);
          connection.Open();
          cmd.ExecuteNonQuery();
          connection.Close();
        }
