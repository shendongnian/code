        static void InsertTextInCell(WorkbookPart wbPart, string sheetName, string addressName)
        {
            Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
                      Where(s => s.Name == sheetName).FirstOrDefault();
            WorksheetPart wsPart =
            (WorksheetPart)(wbPart.GetPartById(theSheet.Id));
            Cell theCell = wsPart.Worksheet.Descendants<Cell>().
                      Where(c => c.CellReference == addressName).FirstOrDefault();
            if (theCell.DataType == null)
            {
                theCell.CellValue = new CellValue("AddString");
            }
        }
