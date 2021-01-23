    if (chkFilename.Checked && chkFileDate.Checked)
    {
        DateTime fromdate = DateTime.Parse(dateTimePicker1.Text);
        DateTime todate = DateTime.Parse(dateTimePicker2.Text);
        if (con.State == ConnectionState.Open)
            con.Close();
        con.Open();
        using(SqlCommand cmd1 = con.CreateCommand())
        {
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = string.Format("SELECT * FROM TBLBackupFile WHERE (DestinationFileName LIKE '%{0}%' OR SourceFileName LIKE '%{0}%') AND (SourceFileDate>='{1:yyyy/MM/dd 00:00:00}' AND SourceFileDate <= '{2:yyyy/MM/dd 23:59:59}')", txtFileName.Text, fromdate, todate);
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }
    }
