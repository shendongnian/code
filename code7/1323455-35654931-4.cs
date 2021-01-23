           using System.IO;
            using (var sw = new StreamWriter(CSVpath))
            {
                sw.WriteLine(string.Join(",", sortedDT.Columns.Cast<DataColumn>().Select(column => column.ColumnName)));
                foreach (DataRow row in sortedDT.Rows)
                {
                   sw.WriteLine(string.Join(",", row.ItemArray.Select(field => field.ToString())));
                }
            }
