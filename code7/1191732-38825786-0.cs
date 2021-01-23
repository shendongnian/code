    DataTable dt = new DataTable();
    using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(filePath, false))
    {
        //Get sheet data
        WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
        IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
        string relationshipId = sheets.First().Id.Value;
        WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
        Worksheet workSheet = worksheetPart.Worksheet;
        SheetData sheetData = workSheet.GetFirstChild<SheetData>();
        IEnumerable<Row> rows = sheetData.Descendants<Row>();
        // Set columns
        foreach (Cell cell in rows.ElementAt(0))
        {
            dt.Columns.Add(cell.CellValue.InnerXml);
        }
        //Write data to datatable
        foreach (Row row in rows.Skip(1))
        {
            DataRow newRow = dt.NewRow();
            for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
            {
                if (row.Descendants<Cell>().ElementAt(i).CellValue != null)
                {
                    newRow[i] = row.Descendants<Cell>().ElementAt(i).CellValue.InnerXml;
                }
                else
                {
                    newRow[i] = DBNull.Value;
                }
            }
            dt.Rows.Add(newRow);
        }
    }
