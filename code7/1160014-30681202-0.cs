    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            var editButton = e.Row.FindControl("_btnUserEdit") as ImageButton;
            UpdatePanel1.Triggers.Add(new  AsyncPostBackTrigger{  
                ControlID=editButton.UniqueID, 
                EventName="click"});
        }
    }
