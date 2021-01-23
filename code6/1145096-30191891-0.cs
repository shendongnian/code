    DBConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=FacesDatabase.mdb";
    DBConnection.Open();
    OleDbCommand command = new OleDbCommand();
    command.Connection = DBConnection;
    for(i = 0; i < MatchName.ToArray().Length; i++)
    {
      string query = "Select FaceID,FaceName,RollNo,FaceImage from " + tableName + " where FaceName='" + MatchName[i].ToString() + "'";
      command.CommandText = query;
      OleDbDataAdapter da = new OleDbDataAdapter(command);
      DataTable dt = new DataTable();
      da.Fill(dt);
      dataGridView1.Rows.Add(dt.Rows);
    }
    DBConnection.Close();
