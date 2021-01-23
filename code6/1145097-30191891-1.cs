    for(i = 0; i < MatchName.ToArray().Length; i++)
    {
      string query = "Select FaceID,FaceName,RollNo,FaceImage from " + tableName + " where FaceName='" + MatchName[i].ToString() + "'";
      command.CommandText = query;
      OleDbDataAdapter da = new OleDbDataAdapter(command);
      DataTable dt = new DataTable();
      da.Fill(dt);
      if (dataGridView1.DataSource == null)
      {
          dataGridView1.DataSource = dt.Clone();
      }
      dataGridView1.Rows.Add(dt.Rows);
    }
