        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].ErrorText = "";
            // Don't try to validate the 'new row' until finished 
            // editing since there
            // is not any point in validating its initial value.
            if (dataGridView1.Rows[e.RowIndex].IsNewRow) { return; }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            bool isValid = true;
            // Convert grid view rows to an IEnumerable collection
            IEnumerable<DataGridViewRow> _dataRows = dataGridView1.Rows.Cast<DataGridViewRow>();
            // Loop through grid view rows
            for (int i = 0; i < _dataRows.Count(); i++)
            {
                if(row.Cells[e.ColumnIndex].Value == _dataRows.ElementAt(i).Cells[e.ColumnIndex].Value)
                {
                    isValid = false;
                    break; // To break from current loop
                }
            }
            if (!isValid)
            {
                e.Cancel = true;
                dataGridView1.Rows[e.RowIndex].ErrorText = "No duplicate values allowed.";
            }
        }
