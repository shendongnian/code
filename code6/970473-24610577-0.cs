    DataTable GetDataTable(GridView dtg)
            {
                DataTable dt = new DataTable();
     
                // add the columns to the datatable            
                if (dtg.HeaderRow != null)
                {
     
                    for (int i = 0; i < dtg.HeaderRow.Cells.Count; i++)
                    {
                        dt.Columns.Add(dtg.HeaderRow.Cells[i].Text);
                    }
                }
     
                //  add each of the data rows to the table
                foreach (GridViewRow row in dtg.Rows)
                {
                    DataRow dr;
                    dr = dt.NewRow();
     
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        dr[i] = row.Cells[i].Text.Replace(" ", "");
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
