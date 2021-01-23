        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == 5 || e.ColumnIndex == 10) && e.Value != null)
                {
                    dataGridView1.Rows[e.RowIndex].Tag = e.Value;
                    e.Value = new String('\u25CF', e.Value.ToString().Length);
                }
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 5 || dataGridView1.CurrentCell.ColumnIndex == 10)//select target column
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.UseSystemPasswordChar = true;
                }
            }
            else
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.UseSystemPasswordChar = false;
                }
            }
            var txtBox = e.Control as TextBox;
            txtBox.KeyDown -= new KeyEventHandler(underlyingTextBox_KeyDown);
            txtBox.KeyDown += new KeyEventHandler(underlyingTextBox_KeyDown);
        }
