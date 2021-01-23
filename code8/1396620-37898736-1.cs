    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 1; i < e.Row.Cells.Count; i++) // Does not process the first cell
            {
                TextBox txt = new TextBox();
                TableCell cell = e.Row.Cells[i];
                txt.Text = cell.Text.Replace("&nbsp;", "");
                cell.Text = "";
                cell.Controls.Add(txt);
            }
        }
        e.Row.Cells.RemoveAt(0); // Removes the first cell in the row
    }
