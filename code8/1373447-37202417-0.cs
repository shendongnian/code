        public int IterateRows(string f, string l)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(locationAndNameOfExcelFile, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = (Microsoft.Office.Interop.Excel._Worksheet)xlWorkbook.Sheets[1];
            var rowsRanged = xlWorksheet.UsedRange.Rows;
            var i = 1;
            //Iterate the rows in the used range
            foreach (Microsoft.Office.Interop.Excel.Range row in rowsRanged)
            {
                var r = row.Row > 1 ? row.Row - i : row.Row;
                var familyNameCellValue = row.Cells[r, 2].Value2.ToString();
                var firstNameCellValue = row.Cells[r, 3].Value2.ToString();
                //var familyNameCellValue = row.Cells[i, 2].Value2.ToString();
                //var firstNameCellValue = row.Cells[i, 3].Value2.ToString();
                if (f == familyNameCellValue && firstNameCellValue == l)
                {
                    return i - 1;
                }
                i++;
            }
            return -1;
        }
