            var file_path = @"D:\doc\excel.xlsx";
            Microsoft.Office.Interop.Excel.Application xlApp =
                new Microsoft.Office.Interop.Excel.ApplicationClass();
            // Disabling messageboxes to prevent losing control on Excel app
            xlApp.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook =
                xlApp.Workbooks.Open(file_path, 0, false, 5, "", "", true,
                    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkBook.DoNotPromptForConvert = true;
            for (var k = 1; k <= xlWorkBook.Worksheets.Count; k++)
            {
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet =
                    (Microsoft.Office.Interop.Excel.Worksheet) this.xlWorkBook.Worksheets.get_Item(k);
                int cCnt = xlWorkSheet.Cells.Count;
                // processing all cells used, but can call named ranges
                Microsoft.Office.Interop.Excel.Range range = xlWorkSheet.UsedRange;
                for (var rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
                {
                    for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                    {
                        Microsoft.Office.Interop.Excel.Range rng =
                            (Microsoft.Office.Interop.Excel.Range) range.Cells[rCnt, cCnt];
                        // do something with range
                    }
                }
            }
