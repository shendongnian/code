     public static void trimData(DataTable dt)
     {
                foreach (DataColumn c in dt.Columns)
                    if (c.DataType == typeof(string))
                        foreach (DataRow r in dt.Rows)
                            try
                            {
                                r[c.ColumnName] = r[c.ColumnName].ToString().Trim();
                            }
                            catch
                            { }
     }
