         private void dataGridView1_EditingControlShowing(object sender,     DataGridViewEditingControlShowingEventArgs e)
        {
        e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
        if (dataGridView1.CurrentCell.ColumnIndex == 0) //Desired Column
        {
        TextBox tb = e.Control as TextBox;
        if (tb != null)
        {
            tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
        }
        }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
        e.Handled = true;
        }
        }
