    private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            if (String.CompareOrdinal(row.Cells["Switch"].Value.ToString(), "L") == 0)
            {
                row.DefaultCellStyle.BackColor = Color.Yellow;
            }
            else if (String.CompareOrdinal(row.Cells["Switch"].Value.ToString(), "B") == 0)
            {
                row.DefaultCellStyle.BackColor = Color.Blue;
            }
        }
