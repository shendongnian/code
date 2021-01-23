    IEnumerable<string> GetNames()
    {
    	// execute your SQL and return result as some abstract collection
		using( /* connection setup */
		{
			using(var command = new SqlCommand("SELECT ImageName FROM [ImageWithTags]", con))
			{
				con.Open();  // check this, maybe it could be opened in first using
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read())
				{
					yield return  reader.GetString(reader.GetOrdinal("ImageName"));
				}
			}
		}
    }
