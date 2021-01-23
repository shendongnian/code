    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string js;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["ondblclick"] = "analyseRow(this)";
        }
    }
