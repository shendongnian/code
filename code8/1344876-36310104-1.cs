            xl.Sheets xlSheets = xlWbk.Sheets;
            xl.Worksheet xlWorkSheet = xlSheets.get_Item(1);
            xl.Range xlUsedRange = xlWorkSheet.UsedRange;
            xlUsedRange.AutoFilter(3, "D", xl.XlAutoFilterOperator.xlAnd, Type.Missing, Type.Missing);
            xl.Range filteredRange = xlUsedRange.SpecialCells(xl.XlCellType.xlCellTypeVisible);
            var names = new List<string>();
            var index = 0;
            foreach (xl.Range areas in filteredRange.Areas)
            {
                var row = areas.Value;
                if (index == 0)  // the first areas contains also the headers, so the first time, you need to read the value from row 2
                {
                    names.Add(row[2, 1]);
                }
                else
                {
                    names.Add(row[1, 1]);
                }
                index++;
            }
