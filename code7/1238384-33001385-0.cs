    using Microsoft.Office.Interop.Excel;
...
            Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = xl.Workbooks.Open(@"C:\test.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet sheet = workbook.Sheets[1];
            int numRows = sheet.UsedRange.Rows.Count;
            int numColumns = 2;     // according to your sample
            List<string[]> contents = new List<string[]>();
            string [] record = new string[2];
            for (int rowIndex = 1; rowIndex <= numRows; rowIndex++)  // assuming the data starts at 1,1
            {
                for (int colIndex = 1; colIndex <= numColumns; colIndex++)
                {
                    Range cell = (Range)sheet.Cells[rowIndex, colIndex];
                    if (cell.Value != null)
                    {
                        record[colIndex-1] = Convert.ToString( cell.Value);
                    }
                }
                contents.Add(record);
            }
            xl.Quit();
            Marshal.ReleaseComObject(xl);
