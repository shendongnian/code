        var couponList 	= new System.Collections.Generic.List<String>(); 
		var queryList 	= new System.Collections.Generic.List<String>(); 
		
		do{
    		var couponKey = generateKey();
			
			//return early for readability
			if(!SearchEpinKey(couponKey)) continue;
			if(couponList.Contains(couponKey)) continue;
			
			//add to coupon list to ensure newly generated key does not duplicate
			couponList.Add(couponKey);
			
			//create query for batch insert, as Sql Connection can be quite expensive
			var query = String.Format("('{0}','Unused', GETDATE())", couponList);
			queryList.Add(query);
   		}
		while (couponList.Count < quantity);
		
		conn = new SqlConnection(connString);
   		conn.Open();
		
		//may be a good idea to use try catch here?
   		using (SqlCommand cmd = new SqlCommand())
   		{
			
			//join all query with , for batch insert
       		string query = "INSERT INTO CouponStock (coupon_key,  status, created_on)";
			query += "VALUES" + string.Join<string>(",", queryList);
			
			cmd.Connection = conn;
       		cmd.CommandType = CommandType.Text;
       		cmd.CommandText = query; 
       		cmd.ExecuteNonQuery();
    	}
    	
		conn.Close();
