    private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int CurrentRow = dataGridView1.CurrentCell.RowIndex;
                CurrentRow++;
                if (CurrentRow < dataGridView1.Rows.Count)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[CurrentRow].Cells[0];
                }
                else
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                }
            }
        }
