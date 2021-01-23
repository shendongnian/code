    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow)
         {
    		Label lblEndDate = (Label)e.Row.FindControl("lblStudyEndDate");
    		TextBox txt_1 = (TextBox)e.Row.FindControl("txt_1");
            DropDownList ddl_1 = (DropDownList)e.Row.FindControl("DropDownList1");
    
    		DateTime EndDate = DateTime.Parse(lblEndDate.Text);
    		if (EndDate < DateTime.Today)
    		{
    			txt_1.Enabled = false;
    			ddl_1.Enabled = false;
    			e.Row.CssClass = "setColorClass"; // css class to set bgcolor , forecolor etc 
    		}
    	}
    }
