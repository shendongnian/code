    List<Dictionary<string, object>> arrResponse = new List<Dictionary<string, object>>();
    DataTable reader = db.executeQueryDataTable(sSQL);
    foreach (DataRow row in reader.Rows)
    {
    	Dictionary<string, object> dictRow = new Dictionary<string, object>();
        foreach(DataColumn col in reader.Columns)
    		dictRow[col.ColumnName] = row[col.ColumnName];
        arrResponse.Add(dictRow);
    
    }
