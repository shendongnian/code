    private void LoadRepeater()
    {
        //load dataset
        _dataTable = myDataSet.Tables[0];
        int columnCount = _dataTable.Columns.Count;
        int half = (int)columnCount/2;
    
        var columnCollection = _dataTable.Columns.OfType<DataColumn>();
        var firstHalfColumns = columnCollection.Take(half);
        var secondHalfColumns = columnCollection.Skip(half);
    
        repeater1.DataSource = firstHalfColumns;
        repeater1.DataBind();
    
        repeater2.DataSource = secondHalfColumns;
        repeater2.DataBind();
    }
