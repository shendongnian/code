    DataTable dtable2;
    DataRow[] rowArray = dataGridView1.SelectedRows;
    If !(rowArray.Length == 0 )
    {
        dTable2 = rowArray.CopyToDataTable();
    }
    
    dataGrodView2.DataSource = dTable2;
