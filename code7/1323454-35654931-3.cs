           using System.IO;
            using (var sw = new StreamWriter(CSVpath))
            {
                var CSVcolumnNames = sortedDT.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                sw.WriteLine(string.Join(",", CSVcolumnNames));
                foreach (DataRow row in sortedDT.Rows)
                {
                    var fields = row.ItemArray.Select(field => field.ToString());
                        sw.WriteLine(string.Join(",", fields));
                }
            }
