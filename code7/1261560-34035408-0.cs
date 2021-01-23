        public void ExportToExcel(ObservableCollection<MobileModel> MobileList)
        {
            if (MobileList.Count > 0)
            {
                // Displays a SaveFileDialog so the user can save the Image
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel File|*.xls";
                saveFileDialog1.Title = "Save an Excel File";
                saveFileDialog1.FileName = "Mobile List";
                
                // If the User Clicks the Save Button then the Module gets executed otherwise it skips the scope
                if ((bool)saveFileDialog1.ShowDialog())
                {
                    Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    if (xlApp != null)
                    {
                        Excel.Workbook xlWorkBook;
                        Excel.Worksheet xlWorkSheet;
                        object misValue = System.Reflection.Missing.Value;
                        xlWorkBook = xlApp.Workbooks.Add(misValue);
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                        xlWorkSheet.Cells[1, 1] = "";
                        Excel.Range formatRange;
                        int rowCount = 1;
                        xlWorkSheet.Cells[rowCount, 1] = "Brand";
                        xlWorkSheet.Cells[rowCount, 2] = "OS";
                        rowCount++;
                        formatRange = xlWorkSheet.get_Range("a1"); formatRange.EntireRow.Font.Bold = true;
                        formatRange = xlWorkSheet.Range["a1"]; formatRange.Cells.HorizontalAlignment = HorizontalAlignment.Center;
                        formatRange = xlWorkSheet.get_Range("b1"); formatRange.EntireRow.Font.Bold = true;
                        foreach (var item in MobileList)
                        {
                            xlWorkSheet.Cells[rowCount, 1] = item.Brand;
                            xlWorkSheet.Cells[rowCount, 2] = item.OS;
                            rowCount++;
                        }
                        formatRange = xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, rowCount - 1]]; formatRange.AutoFilter(1, Type.Missing, Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);
                        xlWorkSheet.Columns.AutoFit();
                        // If the file name is not an empty string open it for saving.
                        if (!String.IsNullOrEmpty(saveFileDialog1.FileName.ToString()) && !string.IsNullOrWhiteSpace(saveFileDialog1.FileName.ToString()))
                        {
                            xlWorkBook.SaveAs(saveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                            xlWorkBook.Close(true, misValue, misValue);
                            xlApp.Quit();
                            releaseObject(xlWorkSheet);
                            releaseObject(xlWorkBook);
                            releaseObject(xlApp);
                            MessageBox.Show("Excel File Exported Successfully", "Export Engine");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nothing to Export", "Export Engine");
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                System.GC.Collect();
            }
        }
