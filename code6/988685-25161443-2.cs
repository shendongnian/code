    foreach(GridViewRow rw in GridViewSmsComplaints.Rows)
    {
       TextBox txtComplainant = ((TextBox)rw.FindControl("txtComplainant"));//added this line to find the control.
        if(rw.RowIndex != RowIndex)
        {
           rw.Enabled = false;
        }
        
        if (ddl.SelectedValue == "0") 
        {
           txtComplainant.Visible = false;
        }
    }
