    using Excel = Microsoft.Office.Interop.Excel;
    .
    .
    .
    
    var app = new Excel.Application();
                
        Excel.Workbook wb = null;
                
                            try
                            {
                                wb = app.Workbooks.Open(@"c:\test.html");
                                wb.SaveAs(@"c:\test.xlsx", Excel.XlFileFormat.xlOpenXMLWorkbook);
                                //wb.SaveCopyAs(@"c:\test.xlsx");
                                wb.Close();
                            }
                            catch (Exception ex)
                            {
                                //_logger.Error(ex);
                            }
                            finally
                            {
                                app.Quit();
                            }
