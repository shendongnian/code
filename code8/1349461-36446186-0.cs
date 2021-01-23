     using Excel = Microsoft.Office.Interop.Excel;//add this library
     Task.Run(() => {                    
                    // load excel, and create a new workbook
                    Excel.Application excelApp = new Excel.Application();
                    excelApp.Workbooks.Add();
                    // single worksheet
                    Excel._Worksheet workSheet = excelApp.ActiveSheet;
                    // column headings
                    for (int i = 0; i < EmployeeDataTable.Columns.Count; i++)
                    {
                        workSheet.Cells[1, (i + 1)] = EmployeeDataTable.Columns[i].ColumnName;
                    }
                    // rows
                    for (int i = 0; i < EmployeeDataTable.Rows.Count; i++)
                    {
                        // to do: format datetime values before printing
                        for (int j = 0; j < EmployeeDataTable.Columns.Count; j++)
                        {
                            workSheet.Cells[(i + 2), (j + 1)] = EmployeeDataTable.Rows[i][j];
                        }
                    }
                    excelApp.Visible = true;
                    // check fielpath
                    /*if (ExcelFilePath != null && ExcelFilePath != "")
                    {
                        try
                        {
                            workSheet.SaveAs(ExcelFilePath);
                            excelApp.Quit();
                            MessageBox.Show("Excel file saved!");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                + ex.Message);
                        }
                    }
                    else    // no filepath is given, the file opens up and the user can save it accordingly.
                    {
                        excelApp.Visible = true;
                    }*/
                    ;
                });
