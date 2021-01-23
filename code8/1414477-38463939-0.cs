    protected void btnNew_Click(object sender, EventArgs e)
    {
        dvFilingDetail.ChangeMode(DetailsViewMode.Insert);
        dvFilingDetail.DataBind();
    
        Button insert = (Button)dvFilingDetail.FindControl("btnInsert");
        Button cancel = (Button)dvFilingDetail.FindControl("btnCancel");
        if (insert != null)
        {
            insert.Visible = true;
        }
        if (cancel != null)
        {
            cancel.Visible = true;
        }
    }
