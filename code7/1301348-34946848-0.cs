    grdViewCases.DataSource = null;
    if (dt.Rows.Count > 0)
    {
        grdViewCases.DataSource = dt;
        grdViewCases.DataBind();
        grdViewCases.Visible = true;
    }
    else
    {
        grdViewCases.EmptyDataText = "No Record Found";
        grdViewCases.DataBind();
        grdViewCases.Visible = true;
    }
