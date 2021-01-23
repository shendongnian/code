    protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow row = ((DataRowView)e.Row.DataItem).Row;
            string process = row.Field<string>("Process"); // change type from string to whatever it is
            Button btn = (Button) e.Row.FindControl("ButtonID");
            btn.Visible = process == "YourProcessValue";
        }
    }
