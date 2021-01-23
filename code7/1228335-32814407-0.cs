     public static DataSet ExtractExcelSheetValuesToDataTable(string xlsxFilePath, string sheetName)
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                using (SpreadsheetDocument myWorkbook = SpreadsheetDocument.Open(xlsxFilePath, true))
                {
                    //Access the main Workbook part, which contains data
                    WorkbookPart workbookPart = myWorkbook.WorkbookPart;
                    WorksheetPart worksheetPart = null;
                    if (!string.IsNullOrEmpty(sheetName))
                    {
                        Sheet ss = workbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == sheetName).SingleOrDefault<Sheet>();
                        worksheetPart = (WorksheetPart)workbookPart.GetPartById(ss.Id);
                    }
                    else
                    {
                        worksheetPart = workbookPart.WorksheetParts.FirstOrDefault();
                    }
                    SharedStringTablePart stringTablePart = workbookPart.SharedStringTablePart;
                    if (worksheetPart != null)
                    {
                        Row lastRow = worksheetPart.Worksheet.Descendants<Row>().LastOrDefault();
                        Row firstRow = worksheetPart.Worksheet.Descendants<Row>().FirstOrDefault();
                        if (firstRow != null)
                        {
                            foreach (Cell c in firstRow.ChildElements)
                            {
                                string value = GetValue(c, stringTablePart);
                                dt.Columns.Add(value);
                            }
                        }
                        if (lastRow != null)
                        {
                            for (int i = 2; i <= lastRow.RowIndex; i++)
                            {
                                DataRow dr = dt.NewRow();
                                bool empty = true;
                                Row row = worksheetPart.Worksheet.Descendants<Row>().Where(r => i == r.RowIndex).FirstOrDefault();
                                int j = 0;
                                if (row != null)
                                {
                                    foreach (Cell c in row.Descendants<Cell>())
                                    {
                                        int? colIndex = GetColumnIndex(((DocumentFormat.OpenXml.Spreadsheet.CellType)(c)).CellReference);
                                        if (colIndex > j)
                                        {
                                            dr[j] = "";
                                            j++;
                                        }
                                        //Get cell value
                                        string value = GetValue(c, stringTablePart);
                                        //if (!string.IsNullOrEmpty(value))
                                        //    empty = false;
                                        dr[j] = value;
                                        j++;
                                        if (j == dt.Columns.Count)
                                            break;
                                    }
                                   
                                    //foreach (Cell c in row.ChildElements)
                                    //{
                                    //    //Get cell value
                                    //    string value = GetValue(c, stringTablePart);
                                    //    //if (!string.IsNullOrEmpty(value))
                                    //    //    empty = false;
                                    //    dr[j] = value;
                                    //    j++;
                                    //    if (j == dt.Columns.Count)
                                    //        break;
                                    //}
                                    //if (empty)
                                    //    break;
                                    dt.Rows.Add(dr);
                                }
                            }
                        }
                    }
                }
                ds.Tables.Add(dt);
                return ds;
            }
            public static string GetValue(Cell cell, SharedStringTablePart stringTablePart)
            {
                if (cell.ChildElements.Count == 0) return null;
                //get cell value
                string value = cell.ElementAt(0).InnerText;//CellValue.InnerText;
                //Look up real value from shared string table
                if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
                    value = stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
                return value;
            }
    
            private static int? GetColumnIndex(string cellReference)
            {
                if (string.IsNullOrEmpty(cellReference))
                {
                    return null;
                }
    
                //remove digits
                string columnReference = Regex.Replace(cellReference.ToUpper(), @"[\d]", string.Empty);
    
                int columnNumber = -1;
                int mulitplier = 1;
    
                //working from the end of the letters take the ASCII code less 64 (so A = 1, B =2...etc)
                //then multiply that number by our multiplier (which starts at 1)
                //multiply our multiplier by 26 as there are 26 letters
                foreach (char c in columnReference.ToCharArray().Reverse())
                {
                    columnNumber += mulitplier * ((int)c - 64);
    
                    mulitplier = mulitplier * 26;
                }
    
                //the result is zero based so return columnnumber + 1 for a 1 based answer
                //this will match Excel's COLUMN function
                return columnNumber;
            }
