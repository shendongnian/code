    protected void yourTasksGV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DateTime dt = DataBinder.Eval(e.Row.DataItem, "DueDate");
            if(dt < DateTime.Today) 
            {
                 e.Row.BackColor = //Your colour.
                 //or do it for a specific cell
                 //e.Row.Cells[0].BackColor = your colour.
            }
        }
    }
