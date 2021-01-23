    DataTable dt = new DataTable();            
    foreach (dynamic record in allRecords)
    {
    	DataRow dr = dt.NewRow();
        foreach (dynamic item in record)
        {
    		var prop = (IDictionary<String, Object>)item;
            if (!dt.Columns.Contains(prop["Column_name"].ToString()))
            {
    			dt.Columns.Add(new DataColumn(prop["Column_name"].ToString()));
    		}
    
            dr[prop["Column_name"].ToString()] = prop["UDS_Data"];
    	}
        dt.Rows.Add(dr);
    }
