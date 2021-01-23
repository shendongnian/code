     //reference library
     using DocumentFormat.OpenXml.Packaging;
     using DocumentFormat.OpenXml.Spreadsheet;
    public class OpenXmlExcel
    {
    public void ExcelToCsv(string source, string target, string delimiter = ";", bool firstRowIsHeade = true)
    {
        var dt = ReadExcelSheet(source, firstRowIsHeade);
        DatatableToCsv(dt, target, delimiter);
    }
    private void DatatableToCsv(DataTable dt, string fname, string delimiter = ";")
    {
       
        using (StreamWriter writer = new StreamWriter(fname))
        {
            foreach (DataRow row in dt.AsEnumerable())
            {
                writer.WriteLine(string.Join(delimiter, row.ItemArray.Select(x => x.ToString())) + delimiter);
            }
        }
    }
    List<string> Headers = new List<string>();
   
    private DataTable ReadExcelSheet(string fname, bool firstRowIsHeade)
    {
        DataTable dt = new DataTable();
        using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fname, false))
        {
            //Read the first Sheets 
            Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
            Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
            IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
            foreach (Row row in rows)
            {
                //Read the first row as header
                if (row.RowIndex.Value == 1)
                {
                    var j = 1;
                    foreach (Cell cell in row.Descendants<Cell>())
                    {
                        var colunmName = firstRowIsHeade ? GetCellValue(doc, cell) : "Field" + j++;
                        Console.WriteLine(colunmName);
                        Headers.Add(colunmName);
                        dt.Columns.Add(colunmName);
                    }
                }
                else
                {
                    dt.Rows.Add();
                    int i = 0;
                    foreach (Cell cell in row.Descendants<Cell>())
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = GetCellValue(doc, cell);
                        i++;
                    }
                }
            }
        }
        return dt;
    }
    private string GetCellValue(SpreadsheetDocument doc, Cell cell)
    {
        string value = cell.CellValue.InnerText;
        if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
        {
            return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
        }
        return value;
     }
    }
