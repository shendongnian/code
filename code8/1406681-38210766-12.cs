    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell commentsCell = e.Row.Cells[commentsColIndex];
            HtmlGenericControl div = new HtmlGenericControl("DIV");
            div.Attributes.Add("class", "innerDiv");
            div.InnerHtml = commentsCell.Text;
            commentsCell.Text = string.Empty;
            commentsCell.Controls.Add(div);
        }
        ...
    }
