    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            Panel Panel1 = (Panel)e.Row.FindControl("Panel1");
            //So on and so forth...
        }
    }
