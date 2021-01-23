    public async Task InitializePartsAsync()
    {
        populator = new Populator();
        detailsDataTable = new DataTable();
        string partSql = "SELECT * FROM tblparts"; 
        await populator.FillDataTableAsync(partSql, detailsDataTable);
        partDetailsDataGridView.DataSource = detailsDataTable;
        detailsCriteriaSearchBox.Text = string.Empty;
    }
    public async Task InitializeTrackAsync()
    {
        populator = new Populator();
        trackDataTable = new DataTable();
        string TrackSql = "SELECT * FROM tblmodule";
        await populator.FillDataTableAsync(TrackSql, trackDataTable);
        trackModulesDataGridView.DataSource = trackDataTable;
        trackCriteriaSearchBox.Text = string.Empty;
    }
