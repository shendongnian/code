            for (int i = 0; i < gridView3.DataRowCount; i++)
            {
                for (int j = 0; j < gridView3.VisibleColumns.Count; j++)
                {
                    if (gridView3.Columns[j].ColumnType == typeof(bool))
                    {
                        string row = Convert.ToString(gridView3.Columns[j]);
                        gridView3.SetFocusedRowCellValue(row, false);
                    }
                }
                gridView3.MoveNext();
            }
