    protected void GrdOpsBook_RowDataBound1(object sender, GridViewRowEventArgs e) 
    {
        foreach (TableCell cell in e.Row.Cells)
        { 
        cell.Text = cell.Text.Replace(">", "");
        cell.Text = cell.Text.Replace("<", ""); 
        } 
    }
