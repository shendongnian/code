        private void control_click(object sender, EventArgs e)
        {
            if (sender is DataGridView)
            {
                DataGridView A = (DataGridView)sender;
                textBox2.Text = A.CurrentCell.RowIndex.ToString();
                textBox1.Text = A.CurrentCell.ColumnIndex.ToString();
                textBox3.Text = A.Name.ToString();
            }
        }
