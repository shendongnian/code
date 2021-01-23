    public void fixGridAlarm(DataGridView gvw)
    {
    	// ...
    	for (int i = 0; i < gvw.Columns.Count; i++)
    		gvw.Columns[i].DataPropertyName = gvw.Columns[i].Name;
    	BindAlarmlarGrid();
    }
