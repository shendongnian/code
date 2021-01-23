    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            HtmlGenericControl div = (HtmlGenericControl)e.Row.FindControl("yourDiv");
            div.Attributes.Add("class", "ClassYouWantToAdd");
        }
    }
