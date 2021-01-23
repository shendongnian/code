            string[] mColumn = null;
            List<string> mlstColumn = new List<string>();
            // get used range of column F
            Range range = excelWorkSheet.UsedRange.Columns["F", Type.Missing];
            // get number of used rows in column F
            int rngCount = range.Rows.Count;
            // iterate over column F's used row count and store values to the list
            for (int i = 1; i <= rngCount; i++)
            {
                mlstColumn.Add(excelWorkSheet.Cells[i, "F"].Value.ToString());
            }
            // List<string> --> string[]
            mColumn = mlstColumn.ToArray();
            // remember to Quit() or the instance of Excel will keep running in the background
            excelApp.Quit();
