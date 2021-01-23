    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt = (TextBox) e.Row.FindControl("txt");
            txt.Visible = e.Row == ((GridView)sender).SelectedRow;
        }
    }
