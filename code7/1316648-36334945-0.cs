    private bool isRevertingChanges;
    
    void OnColumnChanging(object sender, DataColumnChangeEventArgs e)
    {
        if (!isRevertingChanges && e.Column.ColumnName.Equals(TestColumn2))
        {
            if (!e.Row.Table.Columns.Contains(TestColumn2Backup))
                e.Row.Table.Columns.Add(TestColumn2Backup);
    
            e.Row[TestColumn2Backup] = e.Row[TestColumn2];
        }
    }
