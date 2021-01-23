     using Excel = Microsoft.Office.Interop.Excel;//add this library
     Task.Run(() => {                    
                    // load excel, and create a new workbook
                    Excel.Application excelApp = new Excel.Application();
                    excelApp.Workbooks.Add();
                    // single worksheet
                    Excel._Worksheet workSheet = excelApp.ActiveSheet;
                    // column headings
                    for (int i = 0; i < YourDataTable.Columns.Count; i++)
                    {
                        workSheet.Cells[1, (i + 1)] = YourDataTable.Columns[i].ColumnName;
                    }
                    // rows
                    for (int i = 0; i < YourDataTable.Rows.Count; i++)
                    {
                        // to do: format datetime values before printing
                        for (int j = 0; j < YourDataTable.Columns.Count; j++)
                        {
                            workSheet.Cells[(i + 2), (j + 1)] = YourDataTable.Rows[i][j];
                        }
                    }
                    excelApp.Visible = true;
                });
