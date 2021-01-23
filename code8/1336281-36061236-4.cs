    void dataGridView1_EditingControlShowing(object sender, 
                                             DataGridViewEditingControlShowingEventArgs e)
    {
        if (this.dataGridView1.CurrentCell.ColumnIndex == 0)
        {
            var column0TextBox = e.Control as DataGridViewTextBoxEditingControl;
            if (column0TextBox != null)
            {
                column0TextBox.TextChanged -= column0TextBox_TextChanged;
                column0TextBox.TextChanged += column0TextBox_TextChanged;
            }
        }
    }
    void column0TextBox_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var textbox = (TextBox)sender;
            int value0 = Convert.ToInt32(textbox.Text);
            int value1 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
            if (value0 > value1)
                this.dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex]
                                  .ErrorText = "Some Error";
            else
                this.dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex]
                                  .ErrorText = null;
        }
        catch (Exception ex)
        {
            this.dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex]
                              .ErrorText = ex.Message;
        }
    }
