    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if (row.DataGridView.Equals(row.Cells[0].Value))
            {
                row.DefaultCellStyle.ForeColor = Color.White;
                row.DefaultCellStyle.BackColor = Color.White;
                row.Cells[1].Style.Font = new Font(this.Font, FontStyle.Bold);
            }
        }
    }
