    Excel.Worksheet worksheet = excelPackage.Workbook.Worksheets.get_Item(1);
    
    int iRowCount = worksheet.UsedRange.Rows.Count;
    int iColCount = worksheet.UsedRange.Columns.Count;
    
    Excel.Range range;
    
    for (int iRow = 2; iRow <= iRowCount; iRow++) {
        for (int iCol = 1; iCol <= iColCount; iCol++)
            range = (Excel.Range)worksheet.Cells[iRow, iCol];
    
            string content = range.Text.ToString();
    }
