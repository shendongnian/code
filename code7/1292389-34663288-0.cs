    private DataTable _OriginalData;
    private DataTable _SelectedData;
    private void LoadData()
    {
        string yourQuery = "SELECT ... FROM ...";
        _OriginalData = loadMatImpTable(yourQuery);
        //copy structure of original DataTable to the selected table
        _SelectedData = _OriginalData.Clone();
        //Fill DataGridView
        this.matExpDataGridVW.DataSource = _OriginalData;
        this.matImpDataGridVW.DataSource = _SelectedData;
        //Columns will be generate automatically
        //If you want use predefined columns create them through designer or with code
        //And set then DataGridView.AutoGenerateColumns = false;
    }
