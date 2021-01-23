    private DataTable _dataTable;
    
    public void LoadRepeater()
    {
        //load dataset
        _dataTable = myDataSet.Tables[0];
        repeater.DataSource = _dataTable.Columns;
        repeater.DataBind();
    }
    
    public string GetColumnValue(string columnName)
    {
    	return _dataTable.Rows[0][columnName].ToString();
    }
