    public DataSet GetDataSet(string sqlCommand, string ConnectionString)
    {
    	string connectionString = (ConfigurationManager.ConnectionStrings["datConnectionString"].ConnectionString);
    	DataSet ds = new DataSet();
    	using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
    	{
    		cmd.Connection.Open();
    		DataTable rollTable = new DataTable();
    		rollTable.Load(cmd.ExecuteReader());
    		ds.Tables.Add(rollTable);
    
    		if (rollTable.Rows.Count > 0)
    		{
    			foreach (DataRow rw in rollTable.Rows)
    			{
    				//Get StartTime in Time format
    				string StaffID = rw["staff_code"].ToString();
    
    				if (string.IsNullOrEmpty(StaffID) == true)
    				{
    					//Do nothing
    				}
    				else
    				{
    					string ShortStaffID = StaffID.Substring(2);
    					rw["staff_code"] = ShortStaffID.ToString();
    				}
    
    			}
    
    			//Gets data from datatable and inserts it into table within database 
    			string consString = ConfigurationManager.ConnectionStrings["rollPlusConnectionString"].ConnectionString;
    			using (SqlConnection con = new SqlConnection(consString))
    			{
    				using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
    				{
    
    					//Set the database table name
    					sqlBulkCopy.DestinationTableName = "dbo.roll";
    
    					if (rollTable.Rows.Count > 0)
    					{
    						con.Open();
    						sqlBulkCopy.WriteToServer(rollTable);
    						con.Close();
    					}
    					else
    					{
    					}
    				}
    			}
    		}
    	}
    	return ds;
    }
