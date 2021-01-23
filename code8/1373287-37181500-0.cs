        private void interopExcelInsertion(StockHolder sh, int rowNumberToUpdate)
        {
            ExcelInterop.Application oApp;
            ExcelInterop.Worksheet oSheet;
            ExcelInterop.Workbook oBook;
            oApp = new ExcelInterop.Application();
            oBook = oApp.Workbooks.Open(locationAndNameOfExcelFile);
            oSheet = oBook.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet;
            var rowToUpdate = rowNumberToUpdate > 0 ? rowNumberToUpdate : oSheet.Cells.SpecialCells(ExcelInterop.XlCellType.xlCellTypeLastCell, System.Type.Missing).Row;
            int i = 1;
            foreach (var prop in sh.GetType().GetProperties())
            {
                var result = prop.GetValue(sh, null);
                oSheet.Cells[rowToUpdate + 1, i] = result == null ? "" : result.ToString();
                i++;
            }
            oBook.Save();
            oBook.Close();
            oApp.Quit();
            //Marshal.ReleaseComObject(oApp);
        }
