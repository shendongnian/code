    string header = null;
    DataRow row = dataTable.NewRow();
    int i = 0;
    foreach (var value in newValues)
    {
        string newValue = value;
                    
        if (i == 0)
        {
            List<object> headers = valuesDictionnary[0].ToList<Object>();
            int count = 1;
            while (true)
                
                if (headers.Contains(newValue))
                {
                    newValue = value + "_" + count;
                    count++;
                }
                else
                    break;
            header = newValue;
            dataTable.Columns.Add(newValue);
            foreach(DataColumn column in dataTable.Columns)
            {
                row[column.ColumnName] = column.ColumnName;
            }
            dataTable.Rows.InsertAt(row, 0);
        }
        dataTable.Rows[i][header] = newValue;
        i++;
    }
    CsvEngine.DataTableToCsv(dataTable, filePath, new CsvOptions("CSVOptions", delimiter, filePath));
    dataTable.Rows.RemoveAt(0);
