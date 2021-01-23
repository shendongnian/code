    public void exportDtToExcel(DataTable dt, string excelPath, string StrSheetName)
        {
            try
            {
                int ColumnCount;
                if (dt == null || (ColumnCount = dt.Columns.Count) == 0)
                {
                    throw new Exception("Null or empty input table!\n");
                }
                Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                Excel.Workbooks.Add();
               
                Microsoft.Office.Interop.Excel._Worksheet Worksheet = Excel.ActiveSheet;
                object[] Header = new object[ColumnCount];                           
                for (int i = 0; i < ColumnCount; i++)
                {
                    Header[i] = dt.Columns[i].ColumnName;
                }
                Microsoft.Office.Interop.Excel.Range HeaderRange = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, ColumnCount]));
                HeaderRange.Value = Header;
                DataTable tempdtsheet;
                Worksheet = Excel.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);                
                {
                    Worksheet.Name = StrSheetName;
                    tempdtsheet = dt;
                    Worksheet.Activate();
                }              
                Excel.Range cells = Worksheet.Cells;
                try
                {              
                    for (int i1 = 0; i1 < ColumnCount; i1++)
                        Header[i1] = tempdtsheet.Columns[i1].ColumnName;
                    Microsoft.Office.Interop.Excel.Range HeaderRange1 = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, ColumnCount]));
                    HeaderRange1.Value = Header;
                    int RowsCount1 = tempdtsheet.Rows.Count;
                    object[,] Cells1 = new object[RowsCount1, ColumnCount];
                    for (int j = 0; j < RowsCount1; j++)
                        for (int i1 = 0; i1 < ColumnCount; i1++)
                        {
                            Cells1[j, i1] = tempdtsheet.Rows[j][i1];
                        }
                    Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[RowsCount1 + 1, ColumnCount])).Value = Cells1;
                    Worksheet.Columns.AutoFit();
                    ////deleting other sheets
                    ((Microsoft.Office.Interop.Excel.Worksheet)Excel.Worksheets["Sheet3"]).Delete();
                    ((Microsoft.Office.Interop.Excel.Worksheet)Excel.Worksheets["Sheet2"]).Delete();
                    ((Microsoft.Office.Interop.Excel.Worksheet)Excel.Worksheets["Sheet1"]).Delete();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Error" + e1.Message, "Error!!!");
                }
                if (excelPath != null && excelPath != "")
                {
                    try
                    {
                        Worksheet.SaveAs(excelPath);
                        Excel.Quit();
                        MessageBox.Show("Output file is saved");
                        GC.WaitForPendingFinalizers();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        GC.Collect();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Problem with File path." + ex.Message);
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(Worksheet);
                        Marshal.ReleaseComObject(Excel);
                        Worksheet = null;
                    }
                }
                else
                {
                    Excel.Visible = true;
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Error in Exporting : " + exc.Message);
            }
        }
