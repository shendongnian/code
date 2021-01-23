    public static bool OutputFormulae(string filename, string sheetName)
    {
        bool hasFormula = false;
        //open the document
        using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filename, false))
        {
            //get the workbookpart
            WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
            //get the correct sheet
            Sheet sheet = workbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == sheetName).First();
            if (sheet != null)
            {
                //get the corresponding worksheetpart
                WorksheetPart worksheetPart = workbookPart.GetPartById(sheet.Id) as WorksheetPart;
                   
                //iterate the child Cells
                foreach (Cell cell in worksheetPart.Worksheet.Descendants<Cell>())
                {
                    //check for a formula
                    if (cell.CellFormula != null && !string.IsNullOrEmpty(cell.CellFormula.Text))
                    {
                        hasFormula = true;
                        Console.WriteLine("Cell {0} has the formula {1}", cell.CellReference, cell.CellFormula.Text);
                    }
                }
            }
        }
        return hasFormula;
    }
