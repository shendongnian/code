            List<DataTable> tables =
                            ds.Tables.Cast<DataTable>()
                            .Where
                                (dt => !columnNames.Except(dt.Columns.Cast<DataColumn>()
                                    .Select(c => c.ColumnName), StringComparer.OrdinalIgnoreCase)
                                    .Any()
                                )
                            .ToList();
