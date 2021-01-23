        protected void empres1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton button =
            e.Row.Cells[2].FindControl("LinkButtonEdit");
            if (button != null)
            {
                DataRow dr = e.Row.DataItem;
                if (dr["status"].ToString() == "Pending")
                {
                    button.Text = "Edit Details";
                }
                else
                {
                    button.Text = "View Details";
                }
            }
        }
    }
