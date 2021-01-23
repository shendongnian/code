    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        DataGridView dgv = sender as DataGridView;
        if (dgv == null)
            return;
        if (dgv.CurrentRow.Selected)
        {
            dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Red;
            dataGridView1.Rows[0].DefaultCellStyle.ForeColor = Color.White;
        }
    }
