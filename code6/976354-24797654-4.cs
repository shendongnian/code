    protected void imageButtonInsert_Click(object sender, EventArgs e)
    {
    	//Get the gridview row
    	GridViewRow row = (sender as Control).NamingContainer as GridViewRow;
    	DropDownList dropDownListCategory = row.FindControl("dropDownListCategory") as DropDownList;
    	///Similarly you can access the other controls here
    			
    	//If you are using SqlDataSource then you can add/assign these values to the insert parameters
    	//Note that, you need to have insertcommand defined for the sql data source with appropreate parameters
    	SqlDataSource1.InsertParameters.Add("category", dropDownListCategory.SelectedValue);
    	//Similarly assign the other parameter values
    
    	//Call the insert method of the sql data source.
    	SqlDataSource1.Insert();
    
    	//If you are not using data source approach, here you can insert the data to 
    	// database by calling sql command or other ways
    
    
    	//Rebind the gridview.
    	GridView1.DataBind();
    
    }
