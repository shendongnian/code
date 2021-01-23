    public static void CreateSpreadsheetWorkbook(string filepath)
    {
        if (File.Exists(filepath))
            File.Delete(filepath);
        using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filepath, SpreadsheetDocumentType.Workbook))
        {
            // Add a WorkbookPart to the document.
            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();
            // Add a WorksheetPart to the WorkbookPart.
            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            SheetData sheetData = new SheetData();
            worksheetPart.Worksheet = new Worksheet(sheetData);
            // Add Sheets to the Workbook.
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
            // Append a new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet()
            {
                Id = spreadsheetDocument.WorkbookPart.
                    GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = "Sheet1"
            };
            sheets.Append(sheet);
            Row row = new Row()
            {
                RowIndex = 1U
            };
            Cell cell = new Cell()
            {
                CellReference = "A1",
                CellValue = new CellValue("A Test"),
                DataType = CellValues.String
            };
            ExtensionList extensions = new ExtensionList();
            Extension extension = new Extension()
                {
                    Uri = "Testing1234"
                };
            extensions.AppendChild(extension);
            extension.AddNamespaceDeclaration("ns", "http://tempuri/someUrl");
            cell.AppendChild(extensions);
            row.Append(cell);
            sheetData.Append(row);
            workbookpart.Workbook.Save();
            // Close the document.
            spreadsheetDocument.Close();
        }
    }
