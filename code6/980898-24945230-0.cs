    //Global variables
    string currentClass = "alternateDataRow";
    string currentGroup = string.Empty;
    protected void gvPetrols_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Get value from cell, you could also use DataKeys
            //We will assume 2 CSS classes "dataRow", "alternateDataRow"
            string rowGroup = e.Row.Cells[0].Text;
            //swap class if group value changes
            if (rowGroup != currentGroup)
            {
                currentClass = currentClass == "dataRow" ? "alternateDataRow" : "dataRow";
                currentGroup = rowGroup;
            }
            e.Row.CssClass = currentClass;
        }
    }
