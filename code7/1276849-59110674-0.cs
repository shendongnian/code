    public static string ExecuteToJson(this SqlCommand cmd)
    {
    	if (cmd.Connection.State == ConnectionState.Closed)
    	{
    		cmd.Connection.Open();
    	}
    
    	using (DataTable dt = new DataTable())
    	{
    		using (SqlDataAdapter da = new SqlDataAdapter(cmd))
    		{
    			da.Fill(dt);
    
    			List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
    			Dictionary<string, object> row;
    			foreach (DataRow dr in dt.Rows)
    			{
    				row = new Dictionary<string, object>();
    				foreach (DataColumn col in dt.Columns)
    				{
    					row.Add(col.ColumnName, dr[col]);
    				}
    				rows.Add(row);
    			}
    
    			return JsonConvert.SerializeObject(rows);
    		}
    	}
    }
