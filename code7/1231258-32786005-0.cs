            // Load the Excel app
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            // Open the workbook
            var xlWorkbook = xlApp.Workbooks.Open("XLTEST.xlsx");
            // Delcare the sheets and locations to look for names
            Dictionary<string, Tuple<int, int>> worksheets = new Dictionary<string, Tuple<int, int>>()
            {
                // Declare the name of the sheets to look in and the 1 base X,Y index of where to start looking for names on each sheet (i.e. 1,1, = A1)
                { "Sheet1", new Tuple<int, int>(1, 1) },
                { "Sheet2", new Tuple<int, int>(2, 3) },
                { "Sheet3", new Tuple<int, int>(4, 5) },
                { "Sheet4", new Tuple<int, int>(2, 3) },
            };
            // List to keep track of all names in all sheets
            List<string> names = new List<string>();
            // Iterate over every sheet we need to look at
            foreach(var worksheet in worksheets)
            {
                string workSheetName = worksheet.Key;
                // Get this excel worksheet object
                var xlWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Worksheets[workSheetName];
                // Get the 1 based X,Y cell index
                int row = worksheet.Value.Item1;
                int column = worksheet.Value.Item2;
                // Get the string contained in this cell
                string name = (string)(xlWorksheet.Cells[row, column] as Microsoft.Office.Interop.Excel.Range).Value;
                // name is null when the cell is empty - stop looking in this sheet and move on to the next one
                while(name != null)
                {
                    // Add the current name to the list
                    names.Add(name);
                    // Get the next name in the cell below this one
                    name = (string)(xlWorksheet.Cells[++row, column] as Microsoft.Office.Interop.Excel.Range).Value;
                }
            }
            // Compare the number of names to the number of unique names
            if (names.Count() != names.Distinct().Count())
            {
                // You have duplicate names!
            }
