    using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(sFileNameWithPath, false))
    {
        WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
        WorksheetPart worksheetPart = GetWorksheetPart(workbookPart, sSheetName);
    
        SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
        
        bool bHasChildren = sheetData.HasChildren;
        if (bHasChildren)
        {
            for (int iCounter1 = 1; iCounter1 < sheetData.Elements<Row>().Count(); iCounter1++)
            {
                Row rDataRow = sheetData.Elements<Row>().ElementAt(iCounter1);
                for (int iCounter = 0; iCounter < rDataRow.ChildElements.Count; iCounter++)
                {
                    Cell oCell = (Cell)rDataRow.ChildElements[iCounter];
                }
            }
        }
    }
