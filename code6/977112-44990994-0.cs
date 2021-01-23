    public static string[] FirstRowInWorkSheet(string filename, int sheetNumber)
        {
            Application xlsApp = new Application();
            Workbook wb = xlsApp.Workbooks.Open(filename,
                0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true);
            var sheets= wb.Worksheets;
            Worksheet xlWorksheet =sheets[sheetNumber]; 
            int columnCount = xlWorksheet.UsedRange.Columns.Count;
            Range xlRange = xlWorksheet.UsedRange;
            string[] firstRow = new string[columnCount];
            for (int c = 0; c < columnCount; c++)
            {
                if (xlRange.Cells[1, c + 1].Value2 != null)
                {
                    firstRow[c] = xlRange.Cells[1, c + 1].Value2.ToString();
                }
            }
            return firstRow;
        }
