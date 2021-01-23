       var dictionary = new Dictionary<string, List<object>>();
       foreach (DataColumn dataColumn in dataTable.Columns)
       {
           var columnValueList = new List<object>();
           foreach (DataRow dataRow in dataTable.Rows)
           {
                columnValueList.Add(dataRow[dataColumn.ColumnName]);
           }
           dictionary.Add(dataColumn.ColumnName, columnValueList);
       }
