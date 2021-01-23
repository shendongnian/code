    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
        {
            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
        }
        else
        {
            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
        }
    }
