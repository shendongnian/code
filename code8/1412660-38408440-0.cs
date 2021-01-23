    try
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            if (dataGridView1.Columns[columnIndex].HeaderText == "Edit")
            {
                dataGridView1.BeginEdit(true);
                dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    dtEmployee.Rows.RemoveAt(rowIndex);
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show("Sorry for the inconvenience" + ex.ToString() );
        }
