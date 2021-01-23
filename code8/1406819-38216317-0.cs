    foreach (TableCell cell in e.Row.Cells)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string text = cell.Text.Trim();
            cell.BackColor = (String.IsNullOrEmpty(text) || text == "&nbsp;") ? Color.Red : Color.White;
        }
    }
