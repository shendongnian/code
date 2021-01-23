    private void DataAdd_Load(object sender, EventArgs e)
    {
      try
      {
        var conn = new MySqlConnection(@"Server=192.168.1.10;Database=myDB;Uid=myUsername;Pwd=myPassword;");
        conn.Open();
        MessageBox.Show("Connected to database");
      }
      catch (Exception e1)
      {
        MessageBox.Show("Connection failed");
      }
    }
