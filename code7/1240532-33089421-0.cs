            public void typeColumnDataGridView_OnCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView == null || dataGridView.CurrentCell.ColumnIndex != 0) return;
            var dataGridViewComboBoxCell = dataGridView.CurrentCell as DataGridViewComboBoxCell;
            if (dataGridViewComboBoxCell != null)
            {
                if (dataGridViewComboBoxCell.EditedFormattedValue.ToString() == "Custom")
                {
                    //Here we move focus to second cell of current row
                    dataGridView.CurrentCell = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[1];
                    //Return focus to Combobox cell
                    dataGridView.CurrentCell = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[0];
                    //Initiate Edit mode
                    dataGridView.BeginEdit(true);
                    return;
                }
            }
            dataGridView.CurrentCell = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[1];
            dataGridView.BeginEdit(true);
        }
