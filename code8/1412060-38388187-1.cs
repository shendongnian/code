        private void MainWindow_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                try
                {
                    int x = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows[x - 1].Selected = true;
                }
                catch
                {
                    // Index Out Of Range Ex
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    int x = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows[x + 1].Selected = true;
                }
                catch
                {
                    // Index Out Of Range Ex
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
