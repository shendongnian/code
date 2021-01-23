                //Build data as 2D array
            int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            //Create Excel Workbook and Paste
            Excel.Application XLApp = new Excel.Application();
            Excel.Workbook XLWorkBook;
            Excel.Worksheet XLWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            XLWorkBook = XLApp.Workbooks.Add(misValue);
            XLWorkSheet = (Excel.Worksheet)XLWorkBook.Worksheets.get_Item(1);
            //Use range same size as data
            Excel.Range XLRange = (Excel.Range) XLWorkSheet.Range["A1", "B4"];
            XLRange.Value = array2D;
