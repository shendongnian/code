    protected void ProjectTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Set the page index
        this.ProjectTable_PageIndexChanging.PageIndex = e.NewPageIndex;
    
        //Rebind the data
        this.ProjectTable_PageIndexChanging.DataSource = PopulateProjectTable;
        this.ProjectTable_PageIndexChanging.DataBind();
    }
