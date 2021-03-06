            using (IDataReader reader = tcoLst.GetDataReader())
    		using (SqlConnection conn = new SqlConnection(....))
    		using (SqlBulkCopy bcp = new SqlBulkCopy(conn))
    		{
    			conn.Open();
    
                //-->>>>>>>define this value
    			bcp.DestinationTableName = "YourTableName";
    
    			string createTableSql = "";
    
    			createTableSql += "IF EXISTS(SELECT * FROM sys.tables t WHERE t.name = '" 
    				+ bcp.DestinationTableName + "') DROP TABLE " + bcp.DestinationTableName + ";";
    			createTableSql += "CREATE TABLE dbo." + bcp.DestinationTableName + "(";
    
    			for (int column = 0; column < reader.FieldCount; column++)
    			{
    				if (column > 0)
    				{
    					createTableSql += ",";
    				}
    
    				createTableSql += "[" + reader.GetName(column) + "]" + " VARCHAR(MAX) NULL";
    			}
    
    			createTableSql += ");";
    
    			using (SqlCommand createTable = new SqlCommand(createTableSql, conn))
    			{
    				createTable.ExecuteNonQuery();
    			}
    
    			bcp.WriteToServer(reader);
    		}
