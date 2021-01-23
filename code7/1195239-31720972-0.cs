    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
        e.Row.ToolTip = "Click to select this row.";
    }
}
    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
    foreach (GridViewRow row in GridView1.Rows)
    {
        if (row.RowIndex == GridView1.SelectedIndex)
        {
            row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
            row.ToolTip = string.Empty;
        }
        else
        {
            row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            row.ToolTip = "Click to select this row.";
        }
    }
