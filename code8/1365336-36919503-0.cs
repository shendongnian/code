    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the reference of child gridview
            GridView gvDetail = e.Row.FindControl("gvDetail") as GridView;
        }
    }
