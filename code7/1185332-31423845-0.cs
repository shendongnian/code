	private void button2_Click(object sender, EventArgs e)
	{
		using (var con3 = new SqlConnection(DBHandler.GetConnectionString()))
		using (var cmd3 = new SqlCommand("ReadAllImageIDs", con3))
		{
			cmd3.CommandType = CommandType.StoredProcedure;
			using(var dc = new SqlDataAdapter())
			{
				dc.SelectCommand = cmd3;
				dc.Fill(dtt);
				comboBox1.DataSource = dtt;
				comboBox1.DisplayMember = "ID";
				comboBox1.ValueMember = "ID";
			}
		}
	}
