    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Style["display"] = "none";
    
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button btnSelect = e.Row.FindControl("btnSelect") as Button;
            btnSelect.CommandArgument = e.Row.RowIndex.ToString();
            e.Row.Attributes["onclick"] = string.Format("document.getElementById('{0}').click();", btnSelect.ClientID);
        }
    }
