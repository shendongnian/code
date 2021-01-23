    DataRow dataRow = DataTable2.NewRow();
    object o = DataTable1.Rows[index].ItemArray.GetValue(index);
    dataRow.SetField(index, o);
    DataTable2.Rows.InsertAt(dataRow, 0);
    ((DataRowView)(DataGrid2.Items[index])).Row.Delete();
