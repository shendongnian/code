        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            bool isValid = true;
            // Convert grid view rows to an IEnumerable collection
            IEnumerable<DataGridViewRow> _dataRows = dataGridView1.Rows.Cast<DataGridViewRow>();
            // Loop through grid view rows
            for(int i = 0; i < _dataRows.Count(); i++)
            {
                // Check each cell value from the row element 
                for(int j = 0; j < _dataRows.ElementAt(i).Cells.Count; j++)
                {
                    // If new row cell value already exists in the same column
                    if(row.Cells[j].Value == _dataRows.ElementAt(i).Cells[j].Value)
                    {
                        i = int.MaxValue; // To break from outer loop
                        isValid = false;
                        break; // To break from current loop
                    }
                }
            }
            if(!isValid)
                e.Cancel = true; // Cancels the insert of the new row being validated
        }
