        public class OpenXMLHelper
        {
            public static DataTable ExcelWorksheetToDataTable(string pathFilename, string worksheetName)
            {
                DataTable dt = new DataTable(worksheetName);
    
                using (SpreadsheetDocument document = SpreadsheetDocument.Open(pathFilename, false))
                {
                    // Find the sheet with the supplied name, and then use that 
                    // Sheet object to retrieve a reference to the first worksheet.
                    Sheet theSheet = document.WorkbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == worksheetName).FirstOrDefault();
                    if (theSheet == null)
                        throw new Exception("Couldn't find the worksheet: " + worksheetName);
    
                    // Retrieve a reference to the worksheet part.
                    WorksheetPart wsPart = (WorksheetPart)(document.WorkbookPart.GetPartById(theSheet.Id));
                    Worksheet workSheet = wsPart.Worksheet;
    
                    string dimensions = workSheet.SheetDimension.Reference.InnerText;       //  Get the dimensions of this worksheet, eg "B2:F4"
    
                    int numOfColumns = 0;
                    int numOfRows = 0;
                    CalculateDataTableSize(dimensions, ref numOfColumns, ref numOfRows);
                    System.Diagnostics.Trace.WriteLine(string.Format("The worksheet \"{0}\" has dimensions \"{1}\", so we need a DataTable of size {2}x{3}.", worksheetName, dimensions, numOfColumns, numOfRows));
    
                    SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                    IEnumerable<Row> rows = sheetData.Descendants<Row>();
    
                    string[,] cellValues = new string[numOfColumns, numOfRows];
    
                    int colInx = 0;
                    int rowInx = 0;
                    string value = "";
                    SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
    
                    //  Iterate through each row of OpenXML data
                    foreach (Row row in rows)
                    {
                        DataRow dataRow = dt.NewRow();
                        for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                        {
                            //  *DON'T* assume there's going to be one XML element for each item in each row...
                            Cell cell = row.Descendants<Cell>().ElementAt(i);
                            if (cell.CellValue == null || cell.CellReference == null)
                                continue;                       //  eg when an Excel cell contains a blank string
    
                            //  Convert this Excel cell's CellAddress into a 0-based offset into our array (eg "G13" -> [6, 12])
                            colInx = GetColumnIndexByName(cell.CellReference);             //  eg "C" -> 2  (0-based)
                            rowInx = GetRowIndexFromCellAddress(cell.CellReference);  
    
                            //  Fetch the value in this cell
                            value = cell.CellValue.InnerXml;
                            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                            {
                                value = stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
                            }
    
                            cellValues[colInx, rowInx] = value;
                        }
                        dt.Rows.Add(dataRow);
                    }
    
                    //  Copy the array of strings into a DataTable
                    for (int col = 0; col < numOfColumns; col++)
                        dt.Columns.Add("Column_" + col.ToString());
    
                    for (int row = 0; row < numOfRows; row++)
                    {
                        for (int col = 0; col < numOfColumns; col++)
                        {
                            DataRow dataRow = dt.NewRow();
                            dataRow.SetField(col, cellValues[col, row]);
                            dt.Rows.Add(dataRow);
                        }
                    }
    
    #if DEBUG
                    //  Write out the contents of our DataTable to the Output window (for debugging)
                    string str = "";
                    for (rowInx = 0; rowInx < maxNumOfRows; rowInx++)
                    {
                        for (colInx = 0; colInx < maxNumOfColumns; colInx++)
                        {
                            object val = dt.Rows[rowInx].ItemArray[colInx];
                            str += (val == null) ? "" : val.ToString();
                            str += "\t";
                        }
                        str += "\n";
                    }
                    System.Diagnostics.Trace.WriteLine(str);
    #endif
                    return dt;
                }
            }
    
            private static void CalculateDataTableSize(string dimensions, ref int numOfColumns, ref int numOfRows)
            {
                //  How many columns & rows of data does this Worksheet contain ?  
                //  We'll read in the Dimensions string from the Excel file, and calculate the size based on that.
                //      eg "B1:F4" -> we'll need 6 columns and 4 rows.
                //
                //  (We deliberately ignore the top-left cell address, and just use the bottom-right cell address.)
                try
                {
                    string[] parts = dimensions.Split(':');     // eg "B1:F4" 
                    if (parts.Length != 2)
                        throw new Exception("Couldn't find exactly *two* CellAddresses in the dimension");
    
                    numOfColumns = 1 + GetColumnIndexByName(parts[1]);     //  A=1, B=2, C=3  (1-based value), so F4 would return 6 columns
                    numOfRows = GetRowIndexFromCellAddress(parts[1]);
                }
                catch
                {
                    throw new Exception("Could not calculate maximum DataTable size from the worksheet dimension: " + dimensions);
                }
            }
    
            public static int GetRowIndexFromCellAddress(string cellAddress)
            {
                //  Convert an Excel CellReference column into a 1-based row index
                //  eg "D42"  ->  42
                //     "F123" ->  123
                string rowNumber = System.Text.RegularExpressions.Regex.Replace(cellAddress, "[^0-9 _]", "");
                return int.Parse(rowNumber);
            }
    
            public static int GetColumnIndexByName(string cellAddress)
            {
                //  Convert an Excel CellReference column into a 0-based column index
                //  eg "D42" ->  3
                //     "F123" -> 5
                var columnName = System.Text.RegularExpressions.Regex.Replace(cellAddress, "[^A-Z_]", "");
                int number = 0, pow = 1;
                for (int i = columnName.Length - 1; i >= 0; i--)
                {
                    number += (columnName[i] - 'A' + 1) * pow;
                    pow *= 26;
                }
                return number - 1;
            }
        }
