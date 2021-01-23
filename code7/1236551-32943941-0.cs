    protected void gvTransactionDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkId= (LinkButton)e.Row.FindControl("lnkId");
            if (lnkId!= null)
            {
                detailTable.Rows.Add(lnkId.Text);
            }
        }
    }
