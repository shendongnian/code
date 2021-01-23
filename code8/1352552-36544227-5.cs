    public static void ExportToExcel(this DataTable dataTable, string excelFilePath = null)
            {
                try
                {
                    int columnsCount;
    
                    if (dataTable == null || (columnsCount = dataTable.Columns.Count) == 0)
                        throw new Exception("ExportToExcel: Null or empty input table!\n");
    
                    // load excel, and create a new workbook
                    var excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Workbooks.Add();
    
                    // single worksheet
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = excel.ActiveSheet;
    
                    var header = new object[columnsCount];
    
                    // column headings               
                    for (int i = 0; i < columnsCount; i++)
                        header[i] = dataTable.Columns[i].ColumnName;
    
                    Microsoft.Office.Interop.Excel.Range headerRange = worksheet.Range[(Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[1, columnsCount])];
                    headerRange.Value = header;
                    headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSkyBlue);
                    headerRange.Font.Bold = true;
    
                    // DataCells
                    int rowsCount = dataTable.Rows.Count;
                    var cells = new object[rowsCount, columnsCount];
    
                    for (int j = 0; j < rowsCount; j++)
                        for (int i = 0; i < columnsCount; i++)
                            cells[j, i] = dataTable.Rows[j][i];
    
                    worksheet.Range[(Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[rowsCount + 1, columnsCount])].Value = cells;
    
                    try
                    {
                        worksheet.SaveAs(excelFilePath);
                        excel.Quit();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                            + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("ExportToExcel: \n" + ex.Message);
                }
            }
