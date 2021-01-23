    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
        if (dataGridView1.Columns[e.ColumnIndex].Name == "ACTION PROPOSED DATE")
        {
            // Take the other column value for the same row
            var proposedDescription = dg.Rows[e.RowIndex].Cells["ACTION PROPOSED DESCRIPTION"].Value as string;
            if (proposedDescription != null && proposedDescription.IndexOf("file closed", StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                 e.CellStyle.BackColor = Color.Purple;
                 return;
            }
            if (e.Value == null || e.Value == System.DBNull.Value || e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            else
            {
                if (((DateTime) e.Value).Date < (DateTime) DateTime.Now.Date)
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }
    }
