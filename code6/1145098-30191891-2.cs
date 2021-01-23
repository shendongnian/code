    dataGridView1.DataSource = null;
    for (i = 0; i < MatchName.ToArray().Length; i++)
    {
        string query = "Select FaceID,FaceName,RollNo,FaceImage from " + tableName + " where FaceName='" + MatchName[i].ToString() + "'";
        command.CommandText = query;
        OleDbDataAdapter da = new OleDbDataAdapter(command);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dataGridView1.DataSource != null)
        {
            DataTable dt2 = (DataTable)dataGridView1.DataSource;
            dt.Rows.Cast<DataRow>().ToList().ForEach(x => dt2.ImportRow(x));
            dt = dt2;
        }
        dataGridView1.DataSource = dt;
    }
