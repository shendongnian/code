    void SaveBtn_Click(Object sender, EventArgs e) 
    {
        var secondFormTable = (DataTable)secondFormGridControl.DataSouce;
        foreach (DataRow secondFormRow in secondFormTable.Rows)
            switch (secondFormRow.RowState)
            {
                case DataRowState.Added:
                case DataRowState.Modified:
                    DataRow detailsRow;
    
                    if (secondFormRow.RowState == DataRowState.Added)
                    {
                        detailsRow = detailsTable.NewRow();
                        detailsTable.Rows.Add(detailsRow);
                    }
                    else
                        detailsRow = (DataRow)secondFormRow["DetailsRow"];
    
                    foreach (DataColumn column in detailsTable.Columns)
                        detailsRow[column] = secondFormRow[column.ColumnName];
                    break;
    
                case DataRowState.Deleted:
                    ((DataRow)secondFormRow["DetailsRow", DataRowVersion.Original]).Delete();
                    break;
            }
    }
