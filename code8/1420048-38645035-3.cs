    // Given a data table:
    var dt = new DataTable();
    dt.Columns.Add("ITEMNO");
    dt.Rows.Add("1 ");
    dt.Rows.Add(" 1");
    dt.Rows.Add("2");
    
    var dict = new Dictionary<string, bool>();
    
    foreach(DataRow dr in dt.Rows)
    {
    	var itemNo = dr["ITEMNO"].ToString().Trim();
    	
        // Take advantage of O(1) lookup:
    	if (!dict.ContainsKey(itemNo))
    	{
    		dict.Add(itemNo, true);
    	}
    }
    // Get list from dictionary keys:
    var items = new List<string>(dict.Keys);
