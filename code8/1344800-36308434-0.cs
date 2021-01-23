    using (var con = new OleDbConnection(@"Provider=VFPOLEDB;Data Source=c:\Path To Your Data\"))
    {
    	string query = "select * from table1 where ordcust=?";
    	con.Open();
    	OleDbCommand cmd = new OleDbCommand(query, con);
    	cmd.Parameters.AddWithValue("p1", account);
    	var reader = cmd.ExecuteReader();
    	if (reader.Read())
    	{
    		string ordcust = (string)dr[0];
    		string ordnum = (string)dr[1];
    		DateTime orddate = DateTime.Now;
    		string vara = orddate.ToString("dd/MM/yyyy");
    		string cs = "insert into resulttable (ordercustomer,ordnumber,orddate) values (?, ?, ?)";
    
    		var insertCommand = new OleDbCommand(cs, con);
    		insertCommand.Parameters.AddWithValue("p1", ordcust);
    		insertCommand.Parameters.AddWithValue("p2", ordnum);
    		insertCommand.Parameters.AddWithValue("p3", orddate);
    
    		insertCommand.ExecuteNonQuery();
    	}
    	con.Close();
    }
