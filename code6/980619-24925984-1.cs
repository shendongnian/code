     public DataTable DeleteEmptyRows(DataTable dt)
                {
                    DataTable formattedTable = dt.Copy();
                    List<DataRow> drList = new List<DataRow>();
                    foreach (DataRow dr in formattedTable.Rows)
                    {
                        int count = dr.ItemArray.Length;
                        int nullcounter=0;
                        for (int i = 0; i < dr.ItemArray.Length; i++)
                        {
                            if (dr.ItemArray[i] == null || string.IsNullOrEmpty(Convert.ToString(dr.ItemArray[i])))
                            {
                                nullcounter++;
                            }
                        }
        
                        if (nullcounter == count)
                        {
                            drList.Add(dr);
                        }
                    }
        
                    for (int i = 0; i < drList.Count; i++)
                    {
                        formattedTable.Rows.Remove(drList[i]);
                    }
                    formattedTable.AcceptChanges();
        
                    return formattedTable;
                      
                }
