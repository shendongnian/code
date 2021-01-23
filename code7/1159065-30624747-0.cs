    DataTable t = dbTable;
                foreach (var c in dbTable.Columns)
                {
                    var column = (System.Data.DataColumn)c;
                    Console.WriteLine(column.DataType);
                    Console.WriteLine(column.DefaultValue);
                    Console.WriteLine(column.AutoIncrement);
                    Console.WriteLine(column.ColumnName);
                    Console.WriteLine(column.MaxLength);
                    Console.WriteLine(column.Table);
                }
