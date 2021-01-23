    this.dataGridView1.EditingControlShowing += this.DataGridView1_EditingControlShowing;
    private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      e.Control.KeyPress -= new KeyPressEventHandler(AllowNumericOnly);
      if (dataGridView1.CurrentCell.ColumnIndex == 0 || dataGridView1.CurrentCell.ColumnIndex == 1)
      {
        TextBox tb = e.Control as TextBox;
        if (tb != null)
        {
          tb.Tag = dataGridView1.CurrentCell.ColumnIndex == 0 ? 4 : 6;
          tb.KeyPress += new KeyPressEventHandler(this.AllowNumericOnly);
        }
      }
    }
    private void AllowNumericOnly(object sender, KeyPressEventArgs e)
    {
      var control = sender as Control;
      int length = (int)control.Tag;
      if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar) || control.Text.Length >= length))
      {
        e.Handled = true;
      }
    }
