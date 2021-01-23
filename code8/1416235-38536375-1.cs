    private void dataGridView2_SelectionChanged(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dataGridView2.SelectedRows)
        {
            row.DefaultCellStyle.SelectionBackColor = row.DefaultCellStyle.BackColor;
            row.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText; 
                                                   // row.DefaultCellStyle.ForeColor;
        }
        foreach (DataGridViewRow row in dataGridView2.Rows)
            row.DefaultCellStyle.Font = row.Selected ?
                new Font(dataGridView2.Font, FontStyle.Bold) : dataGridView2.Font;
    }
