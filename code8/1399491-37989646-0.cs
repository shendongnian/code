    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((e.RowIndex > -1 && e.ColumnIndex >-1))
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("    X"))
                            e.CellStyle.BackColor = Color.GreenYellow;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
