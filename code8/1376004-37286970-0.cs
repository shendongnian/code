    TextBox columnTextBox; // Form field
    private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (columnTextBox != null)
            columnTextBox.KeyPress -= TextBox_KeyPress;
    }
    private void DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        columnTextBox = e.Control as TextBox;
        if (columnTextBox != null)
            columnTextBox.KeyPress += TextBox_KeyPress;
    }
    private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var textBox = (TextBox)sender;
        // here your logic with textBox
    }
