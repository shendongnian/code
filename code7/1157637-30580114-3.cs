    List<DataTable> tables =
                    ds.Tables
                    .Cast<DataTable>()
                    .Where(dt => !columnNames.Except(dt.Columns.Select(c => c.Name)).Any())
                    .ToList();
