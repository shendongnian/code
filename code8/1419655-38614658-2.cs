    public class SpreadsheetDocumentWrapper : ISpreadsheetDocument {
        private SpreadsheetDocumentWrapper excelDoc;
        public SpreadsheetDocumentWrapper(SpreadsheetDocumentWrapper excelDoc) {
            this.excelDock = excelDock;
        }
    
        public Sheet GetSheet(string name) {
            return excelDoc.WorkbookPart.Workbook.Descendants<Sheet>()
                .SingleOrDefault(s => s.Name == sheetName);
        }
    
        public WorksheetPart GetPartById(string id) {
            return (WorksheetPart)excelDoc.WorkbookPart.GetPartById(id);
        }
    }
