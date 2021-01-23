    public void InitializeParts()
    {
        populator = new Populator();
        detailsDataTable = new DataTable();
        string partSql = "SELECT * FROM tblparts";            
        populator.FillDataTable(partSql, detailsDataTable);
        partDetailsDataGridView.DataSource = detailsDataTable;
        detailsCriteriaSearchBox.Text = string.Empty;
    }
    
    public void InitializeTrack()
    {
        populator = new Populator();
        trackDataTable = new DataTable();
        string TrackSql = "SELECT * FROM tblmodule";
        populator.FillDataTable(TrackSql, trackDataTable);
        trackModulesDataGridView.DataSource = trackDataTable;
        trackCriteriaSearchBox.Text = string.Empty;
    }
