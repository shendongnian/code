    protected void gvClientsArchive_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType ==  DataControlRowType.DataRow)
        {
            LinkButton lnkRestore = (LinkButton)e.Row.FindControl("lnkRestore");
            lnkRestore.Click += new System.EventHandler(this.doRestore);
        }
    }
