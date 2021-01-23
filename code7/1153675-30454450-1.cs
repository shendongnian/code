       DataTable dt = new DataTable();
           int columnCount = dgv.Columns.Count;
               foreach (DataGridViewRow dr in dgv.Rows)
                    {
                        DataRow dataRow = dt.NewRow();
                        for (int i = 0; i < columnCount; i++)
                        {
                            dataRow[i] = dr.Cells[i].Value;
                            //insert statement or save or initialaize or watever u going to do with the text
                           string st=   dataRow.ToString();
                        }
                        dt.Rows.Add(dataRow);
                    }
