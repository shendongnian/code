            for (int i = 2; i <= rowCount; i++)
            {
                string storeId = xlRange.Cells[i, 1].Value2.ToString();
                string employeeId = xlRange.Cells[i, 2].Value2.ToString();
                string employeeName = xlRange.Cells[i, 3].Value2.ToString();
                string position = xlRange.Cells[i, 4].Value2.ToString();
                string hDate = Convert.ToString(xlRange.Cells[i, 5].Value);
                string cDate = Convert.ToString(xlRange.Cells[i, 6].Value);
                table.Rows.Add(storeId, employeeId, employeeName, position, hDate, cDate);
            }
