    //when mouse is over cell
        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Black;
            }
        }
    //when mouse is leaving cell
        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
            }
        }
