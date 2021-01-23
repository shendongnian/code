    private DataTable TransposeTable(DataTable inputTable)
    {
        // create output pivot table and add the "Month" column to it.
        var pivotTable = new DataTable("PivotTable");
        var srcMonthCol = inputTable.Columns["Month"];
        var salesDataType = inputTable.Columns["Sales"].DataType;
        pivotTable.Columns.Add(new DataColumn(srcMonthCol.ColumnName, srcMonthCol.DataType));
        // get unique 'PCode' values
        var uniquePeriods = inputTable.AsEnumerable()
            .Select(x => x.Field<string>("PCode"))
            .Distinct()
            .ToList();
        // Add the unique 'PCode' as columns to the pivot table
        uniquePeriods.ForEach(p => pivotTable.Columns.Add(new DataColumn(p, salesDataType)));
        // Now we have the columns for the pivot table set-up and we need
        // to get the rows, which will be grouped by month.
        var rows = inputTable.AsEnumerable()
            .GroupBy(x => x.Field<string>("Month"))
            .Select(x => {
                var mc = new object[] { x.Key, };
                var salesCols = uniquePeriods
                    .Select(p => x
                        .Where(r => r.Field<string>("PCode") == p)
                        .Select(r => r["Sales"])
                        .FirstOrDefault())
                    .ToArray();
                return mc.Concat(salesCols).ToArray();
            }).ToList();
        // Now we can add the rows.
        rows.ForEach(r => pivotTable.Rows.Add(r));
        // And return the result.
        return pivotTable;
    }
