    void FillData()
	{
	  
	    using (SqlConnection c = new SqlConnection(
		@"Data Source=(LocalDB)\v11.0;" +
    @"AttachDbFilename=C:\Development\C-Sharp\LockItUp\Lockitup.mdf;Integrated Security=True"))
	    {
		c.Open();
		
               string query = "SELECT viewfolder, status FROM Folders WHERE username = '" + Globals.usrName + "' ORDER BY viewfolder";
		using (SqlDataAdapter a = new SqlDataAdapter(
		    query , c))
		{
		    DataTable tbl = new DataTable();
		    a.Fill(tbl);
		    dataGridView1.DataSource = tbl; 
		}
	    }
	}
