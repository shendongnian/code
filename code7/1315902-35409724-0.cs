    wb = excel.Workbooks.Open(fileName);
    worksheet = wb.ActiveSheet;            
    Range usedRange = worksheet.UsedRange;
    
    this.lastRow = usedRange.Rows.Count;
    this.lastCell = usedRange.Columns.Count;
