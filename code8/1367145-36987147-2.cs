    static List<ImportedRecord> ImportRecords()
    {
        var ret = new List<ImportedRecord>();
        var fInfo = new FileInfo(@"C:\temp\book1.xlsx");
        using (var excel = new ExcelPackage(fInfo))
        {
            var wks = excel.Workbook.Worksheets["Sheet1"];
            var lastRow = wks.Dimension.End.Row;
            for (int i = 2; i <= lastRow; i++)
            {
                var importedRecord = new ImportedRecord
                {
                    ChildName = wks.Cells[i, 4].Value.ToString(),
                    SubGroupName = GetCellValueFromPossiblyMergedCell(wks,i,3),
                    GroupName = GetCellValueFromPossiblyMergedCell(wks, i, 2)
                };
                ret.Add(importedRecord);
            }
        }
        return ret;
    }
    static string GetCellValueFromPossiblyMergedCell(ExcelWorksheet wks, int row, int col)
    {
        var cell = wks.Cells[row, col];
        if (cell.Merge)
        {
            var mergedId = wks.MergedCells[row, col];
            return wks.Cells[mergedId].First().Value.ToString();
        }
        else
        {
            return cell.Value.ToString();
        }
    }
