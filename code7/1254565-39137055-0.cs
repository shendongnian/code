    public static DataTable AutoFillBlankCellOfTable(DataTable outputTable)
            {
                for (int i = 0; i < outputTable.Rows.Count; i++)
                {
                    for (int j = 0; j < outputTable.Columns.Count; j++)
                    {
                        if (outputTable.Rows[i][j] == DBNull.Value)
                        {
                            if (i > 0)
                                outputTable.Rows[i][j] = outputTable.Rows[i - 1][j];
                        }
                    }
                }
                return outputTable;
            }
