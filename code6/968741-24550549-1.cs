    // Import Reference to "Microsoft DAO 3.6 Object Library" (COM)
    
    string TargetDBPath = "insert Path to .mdb file here";
    
    DAO.DBEngine dbEngine = new DAO.DBEngine();
    DAO.Database daodb = dbEngine.OpenDatabase(TargetDBPath, false, false, "MS Access;pwd="+"insert your db password here (if you have any)");
    
    DAO.Recordset rs = daodb.OpenRecordset("insert target Table name here", DAO.RecordsetTypeEnum.dbOpenDynaset);
    
    if (rs.RecordCount > 0)
    {
    	rs.MoveFirst();
    	
        while (!rs.EOF)
        {
    		// Load id of row
    		int rowid = rs.Fields["Id"].Value;
    		
    		// Iterate List to find entry with matching ID
    		for (int i = 0; i < costs.Count; i++)
    		{
    			double cost = costs[i].Cost;
    			int id = costs[i].Id;
    
    			if (rowid == id)
    			{
    				// Save changed values
    				rs.Edit();
    				rs.Fields["Id"].Value = cost;
    				rs.Update();
    			}
    		}
    		
            rs.MoveNext();
        }
    }
    rs.Close();
