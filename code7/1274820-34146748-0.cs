	string whrCond = "";
	if (chkFilename.Checked)
    {
		whrCond = "DestinationFileName like '%" + txtFileName.Text + "%' or SourceFileName like '%" + txtFileName.Text + "%'";
	}
	else if (chkFileDate.Checked)
	{
		if(chkFilename.Checked)
			whrCond = whrCond + " AND "
		whrCond = whrCond + "SourceFileDate>='" + fromdate.ToString("yyyy/MM/dd 00:00:00") + "' and SourceFileDate <= '" + todate.ToString("yyyy/MM/dd 23:59:59") + "'";	
	}
	else if (chkexdate.Checked)
	{
		if(chkFileDate.Checked || chkFilename.Checked)
			whrCond = whrCond + " AND "
		whrCond = whrCond + //Whatever your condition is 
	}
	else
	{
		whrCond = "1 = 1";
	}
	if (con.State == ConnectionState.Open)
	{
		con.Close();
	}
	con.Open();
	SqlCommand cmd = con.CreateCommand();
	cmd.CommandType = CommandType.Text;
	cmd.CommandText = "select * from TBLBackupFile where" + whrCond;
	cmd.ExecuteNonQuery();
	DataTable dt = new DataTable();
	SqlDataAdapter da = new SqlDataAdapter(cmd);
	da.Fill(dt);
	dataGridView1.DataSource = dt;
			
