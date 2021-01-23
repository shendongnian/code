    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
    	GridViewRow row = GridView1.Rows[e.RowIndex];
    	//Get the correct cell number of your datetime field		
    	var dateTimeString = row.Cells[4].Controls[0] as TextBox;
    	if (dateTimeString != null)
    	{
    		DateTime dateTime;
    		if (DateTime.TryParse(dateTimeString.Text, out dateTime))
                
    		SqlDataSource1.UpdateParameters["CHECKTIME"].DefaultValue = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
    	}
    }
