    var conditions = new List<string>();
    if(chkFilename.Checked)
    {
        conditions.Add(string.Format("DestinationFileName LIKE '%{0}%' OR SourceFileName LIKE '%{0}%'", txtFileName.Text));
    }
    if(chkFileDate.Checked)
    {
        DateTime fromdate = DateTime.Parse(dateTimePicker1.Text);
        DateTime todate = DateTime.Parse(dateTimePicker2.Text);
        conditions.Add(string.Format("SourceFileDate>='{0:yyyy/MM/dd 00:00:00}' AND SourceFileDate <= '{1:yyyy/MM/dd 23:59:59}'", fromdate, todate));
    }
    if (con.State == ConnectionState.Open)
        con.Close();
    con.Open();
    using(SqlCommand cmd1 = con.CreateCommand())
    {
        cmd1.CommandType = CommandType.Text;
        var condition = "";
        if(conditions.Any())
            condition = string.Format("WHERE {0}", string.Join(" AND ", conditions.Select(c => "(" + c + ")")));
        cmd1.CommandText = string.Format("SELECT * FROM TBLBackupFile {0}", condition);
        cmd1.ExecuteNonQuery();
        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        da1.Fill(dt1);
        dataGridView1.DataSource = dt1;
    }
