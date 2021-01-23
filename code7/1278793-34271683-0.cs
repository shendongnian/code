    using(var con = new SqlConnection("ConnectionString")) {
	using(var cmd = new SqlCommand("ProcedureName", con)) {
		
    //Params here
		
    con.Open();
    using(var reader = cmd.ExecuteReader()) {
		while (reader.Read()) {
			var bValue = reader.GetOrdinal("B");
			//Same for the next two values
			}
		 }
	   }
    }
