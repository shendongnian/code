    HtmlTable table = (HtmlTable)Page.FindControl("mytbl");
    foreach (HtmlTableRow row in table.Rows)
    {
        foreach (HtmlTableCell cell in row.Cells)
        {
            foreach (Control c in cell.Controls)
            {
                if (c.GetType().ToString() == "System.Web.UI.WebControls.CheckBox" && (CheckBox) c).Checked) 
                {
                    //do some operation here
                }
            }
        }
    }
