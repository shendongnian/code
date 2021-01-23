            Excel.Workbook workbook = app.Workbooks.Open(@"yourfilepathandname.xls")
            int rCount = XLRangeTable.Rows.Count;
            int cCount = XLRangeTable.Columns.Count;
            object[,] Table = XLRangeTable.Value2;
            for (int i = 1; i <= cCount; i++)
            {
                T.Columns.Add((string)Table[1, i]);
            }
            for (int j = 2; j <= rCount; j++)
            {
                DataRow R = T.NewRow();
                for (int i = 1; i <= cCount; i++)
                {
                    R[i - 1] = Table[j, i];
                }
                T.Rows.Add(R);
