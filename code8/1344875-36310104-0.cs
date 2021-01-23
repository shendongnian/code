            xl.Sheets xlSheets = xlWbk.Sheets;
            xl.Worksheet xlWorkSheet = xlSheets.get_Item(1);
            xl.Range xlUsedRange = xlWorkSheet.UsedRange;
            xlUsedRange.AutoFilter(3, "D", xl.XlAutoFilterOperator.xlAnd, Type.Missing, true);
            xl.Range filteredRange = xlUsedRange.SpecialCells(xl.XlCellType.xlCellTypeVisible);
            var names = new List<string>();
            foreach (xl.Range areas in filteredRange.Areas)
            {
                names.Add(areas.Value);                
            }
