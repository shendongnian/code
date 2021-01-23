    for (int Row = 0; Row < MyDataTable.Rows.Count; Row++) MyDataTable.Rows[Row].BeginEdit();
    // do your changes in the DataGridView (not the DataTable) here
    UpdateDataGridView();
    // never accept the changes in the DataTable, it will lose the selection in the DataGridView. Problem is that the DataTable is never updated, but this is not a problem in my case.
    //MyDataTable.AcceptChanges();
