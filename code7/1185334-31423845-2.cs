    private void button2_Click(object sender, EventArgs e)
    {
        var dtt = new DataTable();
        using (var dc = new SqlDataAdapter("ReadAllImageIDs", DBHandler.GetConnectionString()))
        {
            dc.SelectCommand.CommandType = CommandType.StoredProcedure;
            dc.Fill(dtt);
        }
        comboBox1.DataSource = dtt;
        comboBox1.DisplayMember = "ID";
        comboBox1.ValueMember = "ID";
    }
	
