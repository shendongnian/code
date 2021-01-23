    private static DataTable FullOuterJoin(
        List<string> joinColumnNames,
        DataTable pullX,
        DataTable pullY)
    {
        var pullYOtherColumns =
            pullY.Columns
                .Cast<DataColumn>()
                .Where(x => !joinColumnNames.Contains(x.ColumnName))
                .ToList();
        var allColumns = 
            pullX.Columns
                .Cast<DataColumn>()
                .Concat(pullYOtherColumns)
                .ToArray();
        var allColumnsClone =
            allColumns
                .Select(x => new DataColumn(x.ColumnName, x.DataType))
                .ToArray();
        DataTable joinedTable = new DataTable();
        joinedTable.Columns.AddRange(allColumnsClone);
        var first =
            LeftOuterJoin(joinColumnNames, pullX, pullY);
        var resultRows = new List<DataRow>();
        foreach (var item in first)
        {
            DataRow newRow = joinedTable.NewRow();
            foreach (DataColumn col in joinedTable.Columns)
            {
                var value = pullX.Columns.Contains(col.ColumnName)
                    ? item.Row1[col.ColumnName]
                    : item.Row2[col.ColumnName];
                newRow[col.ColumnName] = value;
            }
            resultRows.Add(newRow);
        }
        var second =
            LeftOuterJoin(joinColumnNames, pullY, pullX);
        foreach (var item in second)
        {
            DataRow newRow = joinedTable.NewRow();
            foreach (DataColumn col in joinedTable.Columns)
            {
                var value = pullY.Columns.Contains(col.ColumnName)
                    ? item.Row1[col.ColumnName]
                    : item.Row2[col.ColumnName];
                newRow[col.ColumnName] = value;
            }
            resultRows.Add(newRow);
        }
        var uniqueRows =
            resultRows
                .Distinct(
                    new MyEqualityComparer(
                        joinedTable.Columns
                            .Cast<DataColumn>()
                            .Select(x => x.ColumnName)
                            .ToArray()));
        foreach (var uniqueRow in uniqueRows)
            joinedTable.Rows.Add(uniqueRow);
        return joinedTable;
    }
