    List<int> rowIndexes = new List<int>();
    
                        DataView viewCategories = new DataView(ds.Tables["data"]);
                        DataTable dtCategories = viewCategories.ToTable(true, "categorytype");
    
                        // format datatable
                        for(int rowIndex = 0; rowIndex < ds.Tables["data"].Rows.Count; rowIndex++)
                        {
                            DataRow dr = ds.Tables["data"].Rows[rowIndex];
    
                            if (rowIndex < ds.Tables["data"].Rows.Count - 1)
                            {
                                DataRow drNext = ds.Tables["data"].Rows[rowIndex + 1];
    
                                if (dr["categorytype"].ToString() != drNext["categorytype"].ToString())
                                {
                                    rowIndexes.Add(rowIndex);
                                }
                            }   
                        }
    
                        int index = 0;
                        // insert empty rows
                        foreach(int rowIndex in rowIndexes)
                        {
                            index++;
    
                            DataRow newRow = ds.Tables["data"].NewRow();
    
                            ds.Tables["data"].Rows.InsertAt(newRow, rowIndex + index);
                            ds.Tables["data"].AcceptChanges();
                        }
                        
    
                        // clean categories and keep only one
                        foreach (DataRow dr in dtCategories.Rows)
                        {
                            DataView view = ds.Tables["data"].DefaultView;
                            view.RowFilter = "categorytype = '" + dr["categorytype"].ToString() + "'";
    
                            if (view.Count > 1)
                            {
                                int mid = (int)Math.Floor((double)view.Count / (double)2);
    
                                index = 0;
    
                                foreach(DataRowView drView in view)
                                {
                                    if (index != mid) drView["categorytype"] = string.Empty;
                                    index++;
                                }
    
    
                                ds.Tables["data"].AcceptChanges();
    
    
                            }
                        }
