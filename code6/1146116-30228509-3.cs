    var secondFormTable = new DataTable();
    foreach (DataColumn column in detailsTable.Columns)
        secondFormTable.Columns.Add(column.ColumnName, column.DataType);
    secondFormTable.Columns.Add("DetailsRow", typeof(DataRow));
    foreach (var detailsRow in detailsTable.Select("Some filter to get child rows"))
    {
        var secondFormRow = secondFormTable.Rows.Add(detailsRow.ItemArray);
        secondFormRow["DetailsRow"] = detailsRow;
    }
    secondFormTable.AcceptChanges();
    secondFormGridControl.DataSource = secondFormTable;
