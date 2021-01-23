    private Excel.Range IdentifyPivotRanges(Excel.Range xlRange)
    {
        Excel.Range pivotRanges = null;
        Excel.PivotTables pivotTables = xlRange.Worksheet.PivotTables();
        int pivotCount = pivotTables.Count;
        for (int i = 1; i <= pivotCount; i++)
        {
            Excel.Range tmpRange = xlRange.Worksheet.PivotTables(i).TableRange2;
            if (pivotRanges == null) pivotRanges = tmpRange;
            pivotRanges = this.Application.Union(pivotRanges, tmpRange);
        }
        return pivotRanges;
    }
    private void CheckCellsForPivot(Excel.Range xlRange)
    {
        Excel.Range pivotRange = IdentifyPivotRanges(xlRange);
        int rowCount = xlRange.Rows.Count;
        int colCount = xlRange.Columns.Count;
        for (int iRow = 1; iRow <= rowCount; iRow++)
        {
            for (int iCol = 1; iCol <= colCount; iCol++)
            {
                var cell = xlRange.Cells[iRow, iCol];
                if (Application.Intersect(pivotRange, cell) != null)
                {
                    int rowLocation = iRow;
                    int colLocation = iCol;
                }
            }
        }
    }
