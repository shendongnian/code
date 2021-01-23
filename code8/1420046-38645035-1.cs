    // Given a data table:
    var dt = new DataTable();
    dt.Columns.Add("ITEMNO");
    dt.Rows.Add("1 ");
    dt.Rows.Add(" 1");
    dt.Rows.Add("2");
    
    var itemDictionary = new Dictionary<string, bool>();
    
    foreach(DataRow dr in dt.Rows)
    {
    	var itemNumber = dr["ITEMNO"].ToString().Trim();
    	
        // Take advantage of O(1) lookup:
    	if (!itemDictionary.ContainsKey(itemNumber))
    	{
    		itemDictionary.Add(itemNumber, true);
    	}
    }
    // Get list from dictionary keys:
    var itemList = new List<string>(itemDictionary.Keys);
