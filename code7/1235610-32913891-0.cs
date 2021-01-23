    protected void gvProductsParent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
            GridView gvProducts = (GridView)e.Row.FindControl("gvProducts ");
            int count = gvProducts.Rows.Count;
       }
    }
