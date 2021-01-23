	//method to make this code reusable
	//the returned data set is accessible even if the underlying connection is closed
	//NB: that means data's held in memory; so beware of your resource usage
		public DataSet ExecuteSQLToDataSet(string ssConnectionString, string query, string name)
		{
			DataSet ds = new DataSet("Tables");
			using (SqlConnection conn1 = new SqlConnection(ssConnectionString))
			{
				conn1.Open();
				SqlDataAdapter sda = new SqlDataAdapter(query, objConn);
				sda.FillSchema(ds, SchemaType.Source, name);
				sda.Fill(ds, name);
			} //using statement will close and dispose the connection for you
			return ds;
		}
	//example usage
		DataSet ds = ExecuteSQLToDataSet(ssConnectionString, "SELECT FeedURL FROM [dbo].[Feeds]", "Feeds"); //nb: name doesn't have to match table name; you can call it what you like; naming is useful if you wanted to add other result sets to the same data set
		//DataTable tblFeeds = ds.Tables["Feeds"]; //if you want to access the above query by name
		foreach (DataTable tbl in ds.Tables)
		{
			foreach (DataRow dr in tbl.Rows) //tblFeeds.Rows if you did that instead of looping through all tables
			{
				//Console.WriteLine(dr["FeedURL"].ToString()); //you can specify a named column
				Console.WriteLine(dr[0].ToString()); //or just use the index
			}
		}
		Console.WriteLine("Done");
		Console.ReadLine();
