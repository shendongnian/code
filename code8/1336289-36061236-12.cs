    void grid_EditingControlShowing(object sender,DataGridViewEditingControlShowingEventArgs e)
    {
        if (this.grid.CurrentCell.ColumnIndex == 0)
        {
            var textbox = e.Control as DataGridViewTextBoxEditingControl;
            if (textbox != null)
            {
                textbox.TextChanged -= textBox_TextChanged;
                textbox.TextChanged += textBox_TextChanged;
            }
        }
    }
