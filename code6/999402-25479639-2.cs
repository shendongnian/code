    protected void Unnamed_TextChanged(object sender, EventArgs e)
    {
    					
    	var txt = (sender as TextBox).Text;
    	var repeaterItem = (sender as TextBox).NamingContainer as RepeaterItem;
    	var hiddenFieldKey =repeaterItem.FindControl("hiddenFieldKey") as HiddenField;
    
    	// Get data from viewstate
    	DataTable data = ViewState["Data"] as DataTable;
    	var dataRow= data.Rows.Find(hiddenFieldKey.Value);
    	//You can use this row to get the values of the other columns
    
    	int newDays = 0;
    	try
    	{
    		newDays = int.Parse(txt);
    	}
    	catch { return; }
    
    }
