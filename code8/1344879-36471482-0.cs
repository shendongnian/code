        xl.Application xlApp = new xl.Application();
        xl.Workbooks xlWbks = xlApp.Workbooks;
        xl.Workbook xlWbk = xlWbks.Open(@"C:\Temp\Book1.xlsx");
        xl.Sheets xlSheets = xlWbk.Sheets;
        xl.Worksheet xlWorkSheet = xlSheets.get_Item(1);
        xl.Range xlUsedRange = xlWorkSheet.UsedRange;
        xlUsedRange.AutoFilter(3, "D", xl.XlAutoFilterOperator.xlAnd, Type.Missing, Type.Missing);
        xl.Range filteredRange = xlUsedRange.SpecialCells(xl.XlCellType.xlCellTypeVisible);
        var strarrCreateExcel = new List<string>();
        foreach (Excel.Range area in filteredRange.Areas)
            {
                foreach (Excel.Range row in area.Rows)
                {
                    if (!strarrCreateExcel.Contains(((Excel.Range)row.Cells[1, 1]).Text))
                        strarrCreateExcel.Add(((Excel.Range)row.Cells[1, 1]).Text);
                }
            }
