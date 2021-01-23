    private void dataGridView2_SelectionChanged(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dataGridView2.SelectedRows)
        {
            row.DefaultCellStyle.SelectionBackColor = 
                                 dataGridView2.DefaultCellStyle.BackColor;
            row.DefaultCellStyle.SelectionForeColor = 
                                 dataGridView2.DefaultCellStyle.ForeColor;
        }
        foreach (DataGridViewRow row in dataGridView2.Rows)
            row.DefaultCellStyle.Font =   row.Selected ? 
                new Font(dataGridView2.Font, FontStyle.Bold) : dataGridView2.Font;
