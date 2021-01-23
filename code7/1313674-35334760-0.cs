    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Text = dataGridView1.CurrentCell.Value.ToString();
                //do whatever you want to
            }
        }
