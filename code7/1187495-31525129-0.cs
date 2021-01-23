                    int column = 0, row = 0;
                foreach (DataColumn col in dT.Columns)
                {
                    objExcel.Cells[1, ++column] = col.ColumnName;
                }
                foreach (DataRow r in dT.Rows)
                {
                    row++;
                    column = 0;
                    foreach (DataColumn c in dT.Columns)
                    {
                        objExcel.Cells[row + 1, ++column] = r[c.ColumnName];
                    }
                }
