                if (OutputData != null)
                {
                    foreach (DataColumn col in OutputData.Columns)
                    {
                        GridTable.Columns.Add(
                          new DataGridTextColumn
                          {
                              Header = col.ColumnName,
                              Binding = new Binding(string.Format("[{0}]", col.ColumnName))
                          });
                    }
                    GridTable.DataContext = OutputData;
                }
