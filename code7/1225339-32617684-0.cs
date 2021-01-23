    public void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            var enabled = (bool)DataBinder.Eval(e.Row.DataItem, "like_enabled");
            var click_like = e.Row.FindControl("click_like") as ImageButton;
            click_like.Enabled = enabled;
        }
    }
