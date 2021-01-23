     using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand)){
    	using (var dataSet = new DataSet())
    	{
    	  sqlDataAdapter.Fill(dataSet);
    
    	  return dataSet.Tables[0].AsEnumerable().Select(row => new Movie
    	  {
    		MovieID= row["MovieID"].ToString(),
    		Title= row["Title"].ToString(),
    		Rating= row["Rating"].ToString()
    	  });
    	}
    }
