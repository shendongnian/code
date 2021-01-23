                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
    
                    if (xlApp == null)
                    {
                        System.Windows.MessageBox.Show("Excel is not properly installed!!");
                        return;
                    }
                    xlWorkBook = xlApp.Workbooks.Add();
                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    
    
                    xlWorkSheet.Cells[1, 1] = "reg no";
                    xlWorkSheet.Cells[1, 2] = "br no"
                    xlWorkSheet.Cells[1, 3] = "pr no"
                    xlWorkSheet.Cells[1, 4] = "curency";
