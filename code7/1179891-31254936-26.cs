            Excel.Application xlsApp = new Excel.Application();
            Excel._Workbook wrk = xlsApp.Workbooks.Open(@"C:\test.xlsx", 0, true, 5, Missing.Value, Missing.Value, true, Excel.XlPlatform.xlWindows, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            int j=1;
            while (j < 100) {
                xlsApp.Cells[j, 1] = j;
                j = j + 1;
            }
            xlsApp.Visible = true;
