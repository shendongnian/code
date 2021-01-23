    protected void gv1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
             Label lbl = e.Row.FindControl("MyLabel");
             if (lbl.Text == "MyValue")
             {
                 e.Row.Visible = false;
             }
        }
    }
