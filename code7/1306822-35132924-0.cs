    foreach (DataGridViewRow itemRow in dg2.Rows)
                        {
                            if (!itemRow.IsNewRow)
                            {
                                if ((bool)itemRow.Cells[0].EditedFormattedValue)
                                {
     da = new SqlDataAdapter("DELETE FROM allowance WHERE allowanceid = " + Convert.ToInt32(itemRow.Cells[14].Value) + "", cn);
                                    DataTable bb = new DataTable();
                                    da.Fill(bb);
