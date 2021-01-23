	public List<Location> GetAllocation()
	{
		try
		{
			DataTable dt1 = new DataTable();
			string connString = cnst.cnstrin();
			string query = "SELECT * FROM `Mytable`.`location`";
			MySqlDataAdapter ma = new MySqlDataAdapter(query, connString);
			DataSet DS = new DataSet();
			ma.Fill(dt1);
			return dt1.AsEnumerable().Select(row => new Location {
                Id = row["LocationId"],
                Name = row["LocationName"]
            });
		}
		catch (MySqlException e)
		{
			throw new Exception(e.Message);
		}
	}
