    // Caller
    JObject root = new JObject();
    dataToJson(root, connection_string, query, "TableA");
    Console.WriteLine(root.ToString());
    static void dataToJson(JObject parent, string connection_string, string query, string table_name)
    {
    	if (string.IsNullOrEmpty(table_name)) { return; }
    	try
    	{
    		JArray jArray = new JArray();
    		DataTable tbl = new DataTable();
    		//DataTable inner_tbl = new DataTable();
    		SqlConnection conn = new SqlConnection(connection_string);
    		conn.Open();
    		var adapter = new SqlDataAdapter(query, conn); // query to get parent
    		adapter.Fill(tbl);
    		foreach (DataRow row in tbl.Rows)
    		{
    			JObject jo = new JObject();
    			foreach (DataColumn col in tbl.Columns)
    			{
    				jo.Add(new JProperty(col.ColumnName.ToString(), row[col].ToString()));
    			}
    			query = "i have query to get child";
    			// Set the child table name to "table_child"
    			dataToJson(jo, connection_string, query, table_child);  // Pass the JObject as the parent
    
    			jArray.Add(jo); 
    			parent.Add(new JProperty(table_name, jArray));
    		}
    	}
    	catch (Exception e)
    	{
    		WriteLog(e.Message, GetCurrentMethod(e));
    	}
    }
