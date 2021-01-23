    List<string> columnNames = new List<string>();
    var worksheetPart = (WorksheetPart)spreadsheetDocument.WorkbookPart.GetPartById(sheet.Id);
    var sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
    foreach (var r in sheetData.Elements<Row>())
    {
        var columnIndex = 0;
        if (r.RowIndex == "1") // Column Header
        {
            foreach (var c in r.Elements<Cell>())
            {
                columnNames.Add(GetCellValue(spreadsheetDocument.WorkbookPart, c).ToUpper());
            }
        }
