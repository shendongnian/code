    int columnsCount = 0;
	
    //export header
	for (i = 1; i <= this.datagridview1.Columns.Count; i++)
	{
        if (SkipColumn(this.datagridview1.Columns[i - 1]))
            continue;
        columnsCount++;     
		ExcelSheet.Cells[3, columnsCount] = this.datagridview1.Columns[columnsCount - 1].HeaderText;
	}
 
	//export data
	for (i = 1; i <= this.datagridview1.RowCount; i++)
	{
        columnsCount = 0;
		for (j = 1; j <= datagridview1.Columns.Count; j++)
		{
            if (SkipColumn(this.datagridview1.Columns[i - 1]))
                continue;
            
            columnsCount++;
			ExcelSheet.Cells[i + 3, columnsCount] = datagridview1.Rows[i - 1].Cells[columnsCount - 1].Value;
		}
	}
    // ...
    
    private bool SkipColumn(DataGridViewColumn column)
    {
        return column.GetType() == typeof(DataGridViewCheckBoxColumn)
            || column.Name == "Date";
    }
