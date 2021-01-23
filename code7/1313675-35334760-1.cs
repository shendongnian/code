    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int row = dataGridView1.CurrentCell.RowIndex;
                txtID.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                //do whatever you want to
            }
        }
