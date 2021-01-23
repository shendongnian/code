        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
                ((TextBox)e.Control).KeyPress += new KeyPressEventHandler(col1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 2)
                ((TextBox)e.Control).KeyPress += new KeyPressEventHandler(col2_KeyPress);
        }
        void col1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32)
            {
                listBox1.Visible = true;
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }
        void col2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32)
            {
                listBox2.Visible = true;
                listBox2.Focus();
                listBox2.SelectedIndex = 0;
            }
        }
