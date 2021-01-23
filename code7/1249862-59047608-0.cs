     public static DataTable ReadExcelFileToDataTable(string filePath, bool isFirstRowHeader = true)
            {
                #region  Convert xls file to xlsx file
               // Convert xls file to xlsx file --to use below code Microsoft.Excel must installed on the system on which cod eis running
              
                    var app = new Microsoft.Office.Interop.Excel.Application();
                    var web = app.Workbooks.Open("");
                    web.SaveAs(filePath + ".x", FileFormat: Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
                    web.Close();
                    app.Quit();
    
                #endregion
                var newFileName = filePath + ".x";
                DataTable tbl = new DataTable(); ;
    
                Excel.ExcelPackage xlsPackage = new Excel.ExcelPackage(new FileInfo(newFileName));  //using Excel = OfficeOpenXml;    <--EPPLUS
                Excel.ExcelWorkbook workBook = xlsPackage.Workbook;
    
                try
                {
                    Excel.ExcelWorksheet wsworkSheet = workBook.Worksheets[0];
    
                        foreach (var firstRowCell in wsworkSheet.Cells[1, 1, 1, wsworkSheet.Dimension.End.Column]) 
                        {
                            var colName = "";
                            colName = firstRowCell.Text;
                            tbl.Columns.Add(isFirstRowHeader ? colName : string.Format("Column {0}", firstRowCell.Start.Column)); 
                        }
                        var startRow = isFirstRowHeader ? 2 : 1;
                        for (int rowNum = startRow; rowNum <= wsworkSheet.Dimension.End.Row; rowNum++)
                        {
                            var wsRow = wsworkSheet.Cells[rowNum, 1, rowNum, wsworkSheet.Dimension.End.Column];
                            DataRow row = tbl.Rows.Add();
                            foreach (var cell in wsRow)
                            {
                                row[cell.Start.Column - 1] = cell.Text;
                            }
                        }
    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
    
                return tbl;
            }
