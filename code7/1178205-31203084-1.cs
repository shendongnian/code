    protected void OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++ )
            {
                TableCell cell = e.Row.Cells[i];
                cell.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                cell.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                cell.ToolTip = "You can click this cell";
                cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                   , SelectedGridCellIndex.ClientID, i
                   , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
            }
        }
    }
    protected void GridView_SelectedIndexChanged( Object sender, EventArgs e)
    {
        var grid = (GridView) sender;
        GridViewRow selectedRow = grid.SelectedRow;
        int rowIndex = grid.SelectedIndex;
        int selectedCellIndex = int.Parse(this.SelectedGridCellIndex.Value);
    }
