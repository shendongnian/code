        private static SpreadsheetDocument CreateWorkbook(Stream stream)
        {
            // Create the Excel workbook
            var spreadSheet = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook, false);
            // Create the parts and the corresponding objects
            // Workbook
            spreadSheet.AddWorkbookPart();
            spreadSheet.WorkbookPart.Workbook = new Workbook();
            spreadSheet.WorkbookPart.Workbook.Save();
            // Shared string table
            var sharedStringTablePart = spreadSheet.WorkbookPart.AddNewPart<SharedStringTablePart>();
            sharedStringTablePart.SharedStringTable = new SharedStringTable();
            sharedStringTablePart.SharedStringTable.Save();
            // Sheets collection
            spreadSheet.WorkbookPart.Workbook.Sheets = new Sheets();
            spreadSheet.WorkbookPart.Workbook.Save();
            // Stylesheet
            var workbookStylesPart = spreadSheet.WorkbookPart.AddNewPart<WorkbookStylesPart>();
            workbookStylesPart.Stylesheet = new Stylesheet();
            workbookStylesPart.Stylesheet.Save();
            return spreadSheet;
        }
        private static WorksheetPart AddWorksheet(SpreadsheetDocument spreadsheet, string name)
        {
            // Add the worksheetpart
            var worksheetPart = spreadsheet.WorkbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());
            uint sheetId = 1;
            var sheets = spreadsheet.WorkbookPart.Workbook.GetFirstChild<Sheets>();
            if (sheets.Elements<Sheet>().Any())
            {
                sheetId = sheets.Elements<Sheet>().Select(s => s.SheetId.Value).Max() + 1;
            }
            // Add the sheet and make relation to workbook
            var sheet = new Sheet
            {
                Id = spreadsheet.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = sheetId,
                Name = name
            };
            sheets.Append(sheet);
            worksheetPart.Worksheet.Save();
            spreadsheet.WorkbookPart.Workbook.Save();
            return worksheetPart;
        }
