    foreach (GridViewRow row in gridpurchase.Rows)
    {
        GridView gvItems = row.FindControl("gvItems") as GridView;
        gvItems.Columns[0].Visible = false;
        foreach (TableCell cell in row.Cells)
        {
            ...
        }
    }
