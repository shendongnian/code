    for (int r = 0; r < dataTable.Rows.Count - 1; r++) //rows
            {
               
                foreach (DataColumn col in dataTable.Rows[r].Table.Columns)
                {
                    if (!DBNull.Value.Equals(dataTable.Rows[r][col.ColumnName]))
                    {
                        haveValues = true;
                    }
                }
