    using(SqlConnection con = new SqlConnection(ConnectionString))
    {
    	var result = await con.QueryAsync("QueryString", new { param = "param" });
    	return JsonConver.SerializeObject(result);
    }
 
