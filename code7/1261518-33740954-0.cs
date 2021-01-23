    for (int r = 0; r < dataTable.Rows.Count - 1; r++) //rows
            {
               
                foreach (DataColumn col in dt.Columns)
                {
                    if (!DBNull.Value.Equals(dataTable.Rows[r][col.ColumnName]))
                    {
                        haveValues = true;
                    }
                }
