        private void FixTables(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    var columnName = column.ColumnName;
                    if (column.DataType == typeof(DataTable) && row[columnName] != DBNull.Value)
                    {
                        DataTable innerTable = (DataTable)row[columnName];
                        innerTable.TableName = columnName;
                    }
                }
            }
        }
