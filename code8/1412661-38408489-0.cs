      private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int columnIndex = e.ColumnIndex;
                int rowIndex = e.RowIndex;
                string columnValue = dtEmployee.Rows[rowIndex].Cells[columnIndex].HeaderText.ToString();
    
                if (columnValue == "Edit")
                {
                    dataGridView1.BeginEdit(true);
                    dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
                }
                else if (columnValue == "Delete")
                {
                    if (MessageBox.Show("Are you sure you want to delete?", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        dtEmployee.Rows.RemoveAt(rowIndex);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sorry for the inconvenience" + ex.ToString() );
            }
        }
