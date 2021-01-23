            //Total Row
            if (MakeTotalRow == true)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    var colName = dt.Columns[j].ColumnName;
                    if (dt.Columns[j].IsNumeric()) //ensure column data can be summed
                    {
                        try
                        {
                            dr[j] = dt.Compute("Sum(" + colName + ")", "");
                        }
                        catch (SyntaxErrorException e)
                        {
                            //possible syntax error in the column name 
                        }
                    }
                }
                dt.Rows.Add(dr);
            }
