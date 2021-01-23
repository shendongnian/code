    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                // assuming the the ShowEditLink resides in the first column of Grid
                //just changed the index of cells to where the EditLink resides
                LinkButton lb = (LinkButton)e.Row.Cells[0].Controls[0];
                //if you are displaying the PeriodStart in the Grid using BoundField
                //Cells[1] means you are displaying the date in second column, just change the index
                //where you display the date
                DateTime periodStart = Convert.ToDateTime(e.Row.Cells[1].Text);
                if (lb != null) {
                    if (periodStart > DateTime.Now)
                        lb.Visible = true;
                    else
                        lb.Visible = false;
             }
        }
    }
