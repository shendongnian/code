    using (SpreadsheetDocument myDoc = SpreadsheetDocument.Create(filename, SpreadsheetDocumentType.Workbook))
    {
        WorkbookPart workbookpart = myDoc.AddWorkbookPart();
        workbookpart.Workbook = new Workbook();
        // Add a WorksheetPart to the WorkbookPart.
        WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
        SheetData sheetData = new SheetData();
        //add a row
        Row firstRow = new Row();
        firstRow.RowIndex = (UInt32)1;
        //create a cell in C1 (the upper left most cell of the merged cells)
        Cell dataCell = new Cell();
        dataCell.CellReference = "C1";
        CellValue cellValue = new CellValue();
        cellValue.Text = "99999";
        dataCell.Append(cellValue);
        firstRow.AppendChild(dataCell);
        sheetData.AppendChild(firstRow);
        // Add a WorkbookPart to the document.
        worksheetPart.Worksheet = new Worksheet(sheetData);
        //create a MergeCells class to hold each MergeCell
        MergeCells mergeCells = new MergeCells();
                
        //append a MergeCell to the mergeCells for each set of merged cells
        mergeCells.Append(new MergeCell() { Reference = new StringValue("C1:F1") });
        mergeCells.Append(new MergeCell() { Reference = new StringValue("A3:B3") });
        mergeCells.Append(new MergeCell() { Reference = new StringValue("G5:K5") });
        worksheetPart.Worksheet.InsertAfter(mergeCells, worksheetPart.Worksheet.Elements<SheetData>().First());
        //this is the part that was missing from your code
        Sheets sheets = myDoc.WorkbookPart.Workbook.AppendChild(new Sheets());
        sheets.AppendChild(new Sheet()
        {
            Id = myDoc.WorkbookPart.GetIdOfPart(myDoc.WorkbookPart.WorksheetParts.First()),
            SheetId = 1,
            Name = "Sheet1"
        });
    }
