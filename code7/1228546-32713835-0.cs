             [DllImport("user32")]
               private static extern bool GetWindowThreadProcessId(int hWnd, out int id);
                
        
               for(i=0;i<2;i++)
                        {
                    
                         oXL = new Microsoft.Office.Interop.Excel.Application();
                                        oXL.SheetsInNewWorkbook = 1;
                                        oXL.Visible = false;
                        
                                        //Get a new workbook.
                                        oWB = (Excel.Workbook)(oXL.Workbooks.Add(Type.Missing));
          oSheet = (Excel.Worksheet)oWB.Worksheets.get_Item(1);+
                 oSheet.Name = "Summary Report";//Change the name as per your requirment
                                 ExcelRowsCount = 2;
                          for (int RowsCount = 0; RowsCount < dt.Rows.Count; RowsCount++)
                                    {
                         for (int ColumnsCount = 0; ColumnsCount < dt.Columns.Count; ColumnsCount++)
                                        {
                                            if (RowsCount.Equals(0) && ColumnsCount.Equals(0))
                                                oSheet.Cells[2, 1] = dt.Rows[RowsCount][ColumnsCount].ToString();
                                            else
                                                oSheet.Cells[ExcelRowsCount + RowsCount, ColumnsCount + 1] = dt.Rows[RowsCount][ColumnsCount].ToString();
                                        }
    oXL.Visible = false;
            oXL.UserControl = false;
             oXL.DisplayAlerts = false;
            oXL.ActiveWorkbook.SaveAs(FileName, Excel.XlFileFormat.xlWorkbookNormal, "", "", false, false, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
             oWB.Close(false, Type.Missing, Type.Missing);
             oXL.Workbooks.Close();
             oXL.Quit();
               int ExcelID;
                            GetWindowThreadProcessId(oXL.Hwnd, out ExcelID);
                            Process XLProcess = Process.GetProcessById(ExcelID);
                            Marshal.ReleaseComObject(oSheet);
                            Marshal.ReleaseComObject(oWB);
                            Marshal.ReleaseComObject(oXL);
                            XLProcess.Kill();
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                                    } 
             
                    }
        
       
