    public class ExcelDocument {
    
        public WorksheetPart GetWorksheetPart(SpreadsheetDocument excelDoc, string sheetName)
        {
            Sheet sheet = excelDoc.WorkbookPart.Workbook.Descendants<Sheet>()
                .SingleOrDefault(s => s.Name == sheetName);
            if (sheet == null)
            {
                throw new ArgumentException(
                    String.Format("No sheet named {0} found in spreadsheet {1}",
                        sheetName, _filePath), "sheetName");
            }
            return (WorksheetPart)excelDoc.WorkbookPart.GetPartById(sheet.Id);
        }
    }
