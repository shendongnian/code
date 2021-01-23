     private void nameBindingNavigatorSaveItem_Click(object sender, EventArgs e)
    {
      //this.Validate();
      //this.nameBindingSource.EndEdit();
      //this.tableAdapterManager.UpdateAll(this.cLIENTDB3DataSet);
    
      string cmdString = "INSERT INTO Name VALUES (@val1)";
    
      using (connection = new SqlConnection(connectionString))
      {
        using (SqlCommand comm = new SqlCommand(cmdString,connection))
        {
          connection.Open();
          comm.Connection = connection;
          comm.CommandString = cmdString;
          comm.Parameters.AddWithValue("@val1", nameTextBox.Text);
    
          comm.ExecuteNonQuery();
        }
      }
    
    }
