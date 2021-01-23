    private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (!dgv.Columns[e.ColumnIndex].ReadOnly)
        {
            e.CellStyle.BackColor = Color.Yellow;
        }
    }
