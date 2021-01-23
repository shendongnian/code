    public static DataTable Fill_dataTable(string filePath)
    {
        DataTable dt = new DataTable();
        using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, false))
        {
            Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
            Worksheet worksheet = doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart.Worksheet;
            IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
            DataTable dt = new DataTable();
            List<string> columnRef = new List<string>();
            foreach (Row row in rows)
            {
                if (row.RowIndex != null)
                {
                    if (row.RowIndex.Value == 1)
                    {
                        foreach (Cell cell in row.Descendants<Cell>())
                        {
                            dt.Columns.Add(GetValue(doc, cell));
                                columnRef.Add(cell.CellReference.ToString().Substring(0, cell.CellReference.ToString().Length - 1));
                         }
                    }
                    else
                    {
                        dt.Rows.Add();
                        int i = 0;
                        foreach (Cell cell in row.Descendants<Cell>())
                        {
                            while (columnRef(i) + dt.Rows.Count + 1 != cell.CellReference)
                            {
                                dt.Rows(dt.Rows.Count - 1)(i) = "";
                                i += 1;
                             }
                             dt.Rows(dt.Rows.Count - 1)(i) = GetValue(doc, cell);
                             i += 1;
                        }
                    }
                }
            }
        }
        return dt;
    }
