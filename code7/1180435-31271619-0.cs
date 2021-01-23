    DataTable dataTable1;
    dataTable1 = myDataTable.Copy();
    dataTable1.Columns.RemoveAt(4);
    dataTable1.Columns.RemoveAt(5);
    dataTable1.Columns.RemoveAt(6);
    dataTable1.Columns.RemoveAt(7);
    
    DataTable dataTable2;
    dataTable2 = myDataTable.Copy();
    dataTable2.Columns.RemoveAt(0);
    dataTable2.Columns.RemoveAt(1);
    dataTable2.Columns.RemoveAt(2);
    dataTable2.Columns.RemoveAt(3);
