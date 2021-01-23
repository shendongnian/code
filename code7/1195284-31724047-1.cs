     Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = excel.Workbooks.Open(path);
            Worksheet excelSheet = wb.ActiveSheet;
            var test = excelSheet.Cells[x, y].Value.ToString();
            int chk = GetDecimalCount(decimal.Parse(test));
