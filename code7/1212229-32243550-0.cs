    string csvId = string.Empty;
    
    for (int i = 0; i < grdTests.Rows.Count; i++)
    {
    	CheckBox chkTest = (CheckBox)grdTests.Rows[i].FindControl("chkTest");
    	Label lblPtestid = (Label)grdTests.Rows[i].FindControl("lbltestid");
    	string id= lblPtestid.Text;
    	if (chkTest.Checked)
    	{
    		csvId += id + ",";
    		// GetData(id)
    		// Print()
    	}
    	else {} // This is not required actually.
    }
    
    if(!string.IsNullOrEmpty(csvId))
    {
    	// Trim the extra comma at the end.
    	csvId = csvId.Remove(csvId.Length - 1);
    	
    	// Get data for all selected records.
    	GetData(csvId);
    	Print();
    }
    
    public static DataTable gettable(string id)
    {
        string Query = "select * from table where id IN ('" + id + "')";
        DataTable dt = DAL.getData(Query);
        return dt;
    }
