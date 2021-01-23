    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            upGridPager.Update();
            e.Row.SetRenderMethodDelegate(new RenderMethod((w, r) =>
            {
                e.Row.SetRenderMethodDelegate(null);
                using (var ms = new StringWriter())
                using (var writer = new HtmlTextWriter(ms))
                {
                    e.Row.RenderControl(writer);
                    GridPager.InnerHtml = "<table>" + ms.ToString() + "</table>";
                }
            }));
    }
