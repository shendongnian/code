    public static void ReadSheet(string filename, string sheetName)
    {
        using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filename, false))
        {
            WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
            //get the correct sheet
            Sheet sheet = workbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == sheetName).First();
            if (sheet != null)
            {
                WorksheetPart worksheetPart = workbookPart.GetPartById(sheet.Id) as WorksheetPart;
                foreach (Cell cell in  worksheetPart.Worksheet.Descendants<Cell>())
                {
                    ExtensionList extensions = cell.GetFirstChild<ExtensionList>();
                    if (extensions != null)
                    {
                        Extension extension = extensions.GetFirstChild<Extension>();
                        if (extension != null)
                        {
                            Console.WriteLine("Cell {0} has value {1}", cell.CellReference, extension.Uri);
                        }
                    }
                }
            }
        }
    }
