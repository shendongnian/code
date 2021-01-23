    public static void OpenSpreadsheetDocument(string filepath)
    {
        // Open a SpreadsheetDocument based on a filepath.
        using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filepath, false))
        {
            WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
            WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
            string text;
            foreach (Row r in sheetData.Elements<Row>())
            {
                foreach (Cell c in r.Elements<Cell>())
                {
                    text = c.CellValue.Text;
                    Console.Write(text + " ");
                 }
            }
        }
    }
