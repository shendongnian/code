    protected void GridCategoryWise_RowDataBound(object sender, GridViewRowEventArgs e)
        {
    
            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                return;
            }
    
            Button button = (Button)e.Row.FindControl("btnReportedlink");
    
        string Id = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ReportLinks"));
             
            if (Id == "Waiting for Approval")
            {
                button.Enabled = false;
            }
            else
            {
                button.Enabled = true;
            }
    
        }
