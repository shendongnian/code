    protected void lbCont_SelectedIndexChanged(object sender, EventArgs e)
    {
    	DataTable dt = new DataTable();
    
    	switch (lbCont.SelectedIndex)
    	{
    		case 0:
    			dt.TableName = "CountriesTable1";
    			dt.Columns.Add("CountryID");
    			dt.Columns.Add("CountryName");
    			dt.Rows.Add(1, "Country 1a");
    			dt.Rows.Add(2, "Country 1b");
    			dt.Rows.Add(3, "Country 1c");
    			break;
    
    		case 1:
    			dt.TableName = "CountriesTable2";
    			dt.Columns.Add("CountryID");
    			dt.Columns.Add("CountryName");
    			dt.Rows.Add(1, "Country 2a");
    			dt.Rows.Add(2, "Country 2b");
    			dt.Rows.Add(3, "Country 2c");
    			break;
    
    		case 2:
    			dt.TableName = "CountriesTable3";
    			dt.Columns.Add("CountryID");
    			dt.Columns.Add("CountryName");
    			dt.Rows.Add(1, "Country 3a");
    			dt.Rows.Add(2, "Country 3b");
    			dt.Rows.Add(3, "Country 3c");
    			break;
    
    		default:
    			break;
    	}
    
    	ddlCount.DataSource = dt;
    	ddlCount.DataTextField = "CountryName";
    	ddlCount.DataValueField = "CountryID";
    	ddlCount.DataBind();
    	
    	// Same as yours
        ListItem liSelectCount = new ListItem("Select a country...", "-1");
    	ddlCount.Items.Insert(0, liSelectCount);
    }
