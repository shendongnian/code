    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
                if (c.State != ConnectionState.Open)
                {
                    c.Open();
                }
                string command = "";
                string columns = "";
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name; // get column name of edited cell
                if (dataGridView1.Columns.Count != 1) // If there is only one column we dont have any where comparison, so we need oldValue of cell (we took value at cellbeginedit event)
                {
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        if (i != e.ColumnIndex) 
                        {
                            columns += dataGridView1.Columns[i].Name + "= '" + dataGridView1.Rows[e.RowIndex].Cells[i].Value.ToString() + "'"; // compare statement according to other cells (assume that we don't have PK)
                        }
                    }
                    command = "Update Table set " + columnName + "=@newValue where " + columns;
                }
                else
                {
                    command = "Update Table set  " + columnName + "=@newValue where ColumName=" + "'" + oldValue + "'";
                }
                newValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(); //our new parameter.
                cmd = new SqlCommand(command, c);
                cmd.Parameters.AddWithValue("@newValue", newValue);
                cmd.ExecuteNonQuery();
                c.Close();
    }
