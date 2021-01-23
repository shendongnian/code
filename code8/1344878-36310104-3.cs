            private void AutoFilterNames()
        {
            xl.Application xlApp = new xl.Application();
            xl.Workbooks xlWbks = xlApp.Workbooks;
            xl.Workbook xlWbk = xlWbks.Open(@"C:\Temp\Book1.xlsx");
            xl.Sheets xlSheets = xlWbk.Sheets;
            xl.Worksheet xlWorkSheet = xlSheets.get_Item(1);
            xl.Range xlUsedRange = xlWorkSheet.UsedRange;
            xlUsedRange.AutoFilter(3, "D", xl.XlAutoFilterOperator.xlAnd, Type.Missing, Type.Missing);
            xl.Range filteredRange = xlUsedRange.SpecialCells(xl.XlCellType.xlCellTypeVisible);
            var names = new List<string>();
            for (int areaId = 2; areaId <= filteredRange.Areas.Count; areaId++)
            {
                xl.Range areaRange = filteredRange.Areas[areaId];
                object[,] areaValues = areaRange.Value;
                names.Add(areaValues[1, 1].ToString());
            }
            
            var namesToArray = names.ToArray();
        }
