    protected void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i < GridView.Rows.Count - 1; i++)
        {
            Button status = (Button)GridView.Rows[i].FindControl("lnkbtnInfo"); // find control from your button ID
            String state = status.CommandArgument.ToString(); // assume the value given by Eval data binding
            if (state.Equals("confirmed") || state.Equals("rejected"))
            {
                status.Text = "view";
            }
            else // if (state.Equals("pending"))
            {
                status.Text = "review";
            }
        }
    }
