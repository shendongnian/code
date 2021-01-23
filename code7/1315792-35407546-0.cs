                    xlApplication = new Microsoft.Office.Interop.Excel.Application();
    
                    // Create workbook .  
                    xlWorkBook = xlApplication.Workbooks.Add(Type.Missing);
    
                    // Get active sheet from workbook  
                    xlWorkSheet = xlWorkBook.ActiveSheet;
                    xlWorkSheet.Name = "Report";
                    xlWorkSheet.Columns.ColumnWidth = 30;
                   
                    
                    xlApplication.DisplayAlerts = false;
                    for (int rowIndex = 0; rowIndex < gridViewDataTable.Rows.Count; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < gridViewDataTable.Columns.Count; colIndex++)
                        {
                            if (rowIndex == 0)
                            {
                                xlWorkSheet.Cells[rowIndex + 1, colIndex + 1] = gridViewDataTable.Columns[colIndex].ColumnName;
                                xlWorkSheet.Cells[rowIndex + 1, colIndex + 1].Interior.Color = System.Drawing.Color.LightGray;
                            }
                            xlWorkSheet.Cells[rowIndex + 2, colIndex + 1].Borders.Color = Color.Black;
                            xlWorkSheet.Cells[rowIndex + 2, colIndex + 1].Interior.Color = System.Drawing.Color.White;
                            xlWorkSheet.Cells[rowIndex + 2, colIndex + 1] = gridViewDataTable.Rows[rowIndex][colIndex];  
                        }
                    }
                    xlWorkBook.SaveAs(filename);
                    xlWorkBook.Close();
                    xlApplication.Quit();
