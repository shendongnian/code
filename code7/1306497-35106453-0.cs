    public static SqlConnection myConnection = null;
    private void DBConnectBtn_Click(object sender, EventArgs e)
    {
      try
      {
        var myConnection = new SqlConnection(DBConnectionBox.Text);
        myConnection.Open();
        if (myConnection.State == ConnectionState.Closed)
          MessageBox.Show("SUCCESS!!");
      }
      catch (Exception ex)
      { MessageBox.Show($"Failed to connect. Message {ex.Message}"); }
    }
