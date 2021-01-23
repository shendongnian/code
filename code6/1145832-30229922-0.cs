    protected void gvSyncQueueList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSyncQueueList.PageIndex = e.NewPageIndex;
        //To view all the sync results when the page first time loads or when the drop down value is all.
        if (ddlProjectId.SelectedValue.ToString().Equals("All") || string.IsNullOrEmpty(ddlProjectId.SelectedValue.ToString()))
            gvSyncQueueList.DataSource = (DataTable)ViewState["SyncResults"];
        //To bind the project results according to drop down value selected in paging.
        else
        {
            DataView viewResults = new DataView((DataTable)ViewState["SyncResults"]);
            viewResults.RowFilter = "ProjectId =" + Convert.ToInt32(ddlProjectId.SelectedValue);
            gvSyncQueueList.DataSource = viewResults;
        }
        gvSyncQueueList.DataBind();
        string activetab = GetActiveTab();
        ShowTabs(activetab);
    }
