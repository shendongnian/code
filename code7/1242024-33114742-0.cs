    void gvTemplateFields_RowCreated(Object sender, GridViewRowEventArgs e)
    {
    	if(e.Row.RowType == DataControlRowType.DataRow)
    	{
    		(DropDownList)riskWorkDropDownList = (DropDownList)e.Row.FindControl("RiskWorkDropDownList");
    		
    		riskWorkDropDownList.DataSource = dataTable; //Your data table
    		riskWorkDropDownList.DataBind(); 
    	}
    }
