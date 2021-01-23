    protected void GridViewID_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // if you want the whole row class
            e.Row.CssClass = isGov ? "cell_weekday" : "cell_weekend";
            // if you want specific cell class
            e.Row.Cells[2] = isGov ? "cell_weekday" : "cell_weekend";
        }
    }
