    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex == GridView1.EditIndex)
        {
            TextBox txtBox = e.Row.FindControl("TweetTB") as TextBox;
            ...
        }
        ...
    }
