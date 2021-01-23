    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // find the hideme div
            HtmlGenericControl div = (HtmlGenericControl)e.Row.FindControl("hideme");
            // set the visible property
            div.Visible = false;
        }
    }
