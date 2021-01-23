    private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
         if (e.Button == System.Windows.Forms.MouseButtons.Right && e.RowIndex >= 0)
         {
               dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
         }
     }
