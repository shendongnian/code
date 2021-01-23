    protected void gdv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lnk = (HyperLink)e.Row.FindControl("lnk");
            lnk.NavigateUrl = "otherpage.aspx?id=" + ((DataRowView)e.Row.DataItem)["Id"].ToString();
            lnk.Text = ((DataRowView)e.Row.DataItem)["Text"].ToString();
        }
    }
