       private void btnExport_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            int[] ColumnsToInclude = { 0, 2 };
            Int16 i;
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            for (int ix = 0; ix < ColumnsToInclude.Length; ix++)
                xlWorkSheet.Cells[1, ix + 1] = dgvSlipRecord.Columns[ColumnsToInclude[ix]].HeaderText;
            for (i = 0; i <= dgvSlipRecord.RowCount - 2; i++)
            {
                for (int j = 0; j < ColumnsToInclude.Length; j++)
                {
                    xlWorkSheet.Cells[i + 2, j + 1] = dgvSlipRecord[ColumnsToInclude[j], i].Value.ToString();
                }
            }
            xlWorkBook.SaveAs(@"c:\temp\csharp.net-informations.xls", XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }
