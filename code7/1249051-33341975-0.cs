    protected void GrdLimitAndUtilization_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink lnkExcess = (HyperLink)e.Row.FindControl("lnkExcess");
            //Access hyperlink's properties here.
         }
    }
