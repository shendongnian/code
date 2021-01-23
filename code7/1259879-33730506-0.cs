    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    	SqlConnection con = Connection.DBconnection();
    	if (e.CommandName == "EditRow")
    	{
    	
    	   GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
    		HiddenField imgSRC = (HiddenField)row.FindControl("hd_gv");
    		hd_update.Value=imgSRC.Value;
    	}
   
