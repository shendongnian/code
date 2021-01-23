     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DataBinder.Eval(e.Row.DataItem, "Reason").ToString() == "Reason")
            {
                e.Row.Visible= false;
            }
        }
    }
