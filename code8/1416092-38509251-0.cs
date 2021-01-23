	protected void btn_insert_Click(object sender, EventArgs e)
	{
		DataSet ds = new DataSet();
		
		// i would not use Session unless necessary but that is out of scope for the question
		// also do not forget to dispose the datatabale when finished and remove it from the session
		ds = (DataSet)Session["DTset"];
		
		// always wrap your SqlConnection in a using block
		// it ensures the connection is always released
		// also there is no reason to have this inside the loop
		// there is no reason to close/reopen it every time
		using(SqlConnection con = new SqlConnection(connStr))
		{
			con.Open(); // open once
			for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
			{
				// do not convert everything to strings, pick the correct type as it is in the table or convert it to the correct type if the table contains only strings
				string Id = ds.Tables[0].Rows[i][0].ToString();
				string Name = ds.Tables[0].Rows[i][1].ToString();
			
				cmd = new SqlCommand("insert into tbl1(ID,Name) values (@ID,@Name)";
				cmd.Parameters.AddWithValue("@ID", Id).SqlDbType = SqlDbType.; // pick the correct dbtype
				cmd.Parameters.AddWithValue("@Name", Name).SqlDbType = SqlDbType.; // pick the correct dbtype
				int j= cmd.ExecuteNonQuery();
				// do not convert everything to strings, pick the correct type as it is in the table or convert it to the correct type if the table contains only strings
				string Id1 = ds.Tables[0].Rows[i][2].ToString();
				string Name1 = ds.Tables[0].Rows[i][3].ToString();
				string VehicleTypeId = ds.Tables[0].Rows[i][4].ToString();
				string VehicleType = ds.Tables[0].Rows[i][5].ToString();
				string Capacity = ds.Tables[0].Rows[i][6].ToString();
				
				string InsQuery = "insert into tbl2(Id,Name,Subject,status,review) values (@Id,@Name,@Subject,@status,@review)";
				cmd = new SqlCommand(InsQuery,con);
				cmd.Parameters.AddWithValue("@id", Id1).SqlDbType = SqlDbType.; // pick the correct dbtype
				cmd.Parameters.AddWithValue("@Name", name1).SqlDbType = SqlDbType.; // pick the correct dbtype
				// add the rest of your parameters here
				
				int k=  cmd.ExecuteNonQuery();
			}
		}
	}
