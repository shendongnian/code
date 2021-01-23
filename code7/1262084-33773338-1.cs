    public DataTable AddingRecursive(DataTable table)
            {
                for (int i = table.Rows.Count - 1; i >= 0; i--)
                {
                    if (Convert.ToInt64(table.Rows[i]["Parent ID"]) != 0)
                    {
                        Int64 parentNode = Convert.ToInt64(table.Rows[i]["Parent ID"]);
                        Decimal value = Convert.ToDecimal(table.Rows[i]["Values"]);
                        foreach (DataRow row in table.Rows)
                        {
                            if (parentNode == Convert.ToInt64(row["ID"]))
                            {
                                row["Values"] = Convert.ToDecimal(row["Values"]) + value;
                            }
                        }
                    }
                }
                return table;
            }
