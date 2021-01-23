    protected void OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for(int i = 0; i <  e.Row.Cells.Count; i++)
            {
                TableCell cell = e.Row.Cells[i];
                cell.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                cell.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                cell.ToolTip = "You can click this cell";
                cell.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}|{1}", e.Row.RowIndex, i));
            }
        }
    }
