                for (j = 0; j <= ds.Tables[0].Columns.Count-1; j++)
                {
                    for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
                    {                        
                        xlWorkSheet.Cells[1, k + 1] = ds.Tables[0].Columns[k].ColumnName;                        
                    }
                    xlWorkSheet.Cells[i + 2, j + 1] = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                }
            }`
