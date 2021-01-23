        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Whatever index is your checkbox column
            var columnIndex = 0;
            if (e.ColumnIndex == columnIndex)
            {
                // If the user checked this box, then uncheck all the other rows
                var isChecked = (bool)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (isChecked)
                {
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            row.Cells[columnIndex].Value = !isChecked;
                        }
                    }
                }
            }
        }
