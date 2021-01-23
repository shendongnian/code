    private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Parent Problem Combobox
            if (e.ColumnIndex == x && e.RowIndex != -1)
            {
                DataGridViewComboBoxCell cbx = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells[indexofparent];
                if (cbx?.Items != null)
                    cbx.Items.Clear();
                // Populate RESULT datatable from a SQL query
                
                foreach (DataRow item in result.Rows)
                {
                    if (!string.IsNullOrWhiteSpace(item[0].ToString()))
                        cbx.Items.Add(item[0].ToString());
                }
            }
            // Populate child
            else if (e.ColumnIndex == x && e.RowIndex != -1)
            {
                DataGridViewComboBoxCell cbx = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells[indexofchild];
                if (cbx?.Items != null)
                    cbx.Items.Clear();
                // Populate RESULT datatable from a SQL query
                
                foreach (DataRow item in result.Rows)
                {
                    if (!string.IsNullOrWhiteSpace(item[0].ToString()))
                        cbx.Items.Add(item[0].ToString());
                }
            }
        }
