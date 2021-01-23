    /// <summary>
    /// Overrided method to tab only in a DataGridComboBox column.
    /// </summary>
    /// <param name="msg">A Message, passed by reference, that represents the window message to process.</param>
    /// <param name="keyData">One of the Keys values that represents the key to process.</param>
    /// <returns>True if the character was processed by the control. Otherwise, False.</returns>
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        bool TabIsPressed = ((keyData == Keys.Tab) || (keyData == (Keys.Shift | Keys.Tab))); // Checks if Tab or Shift/Tab is pressed.
        Control CurrentControl = this.ActiveControl; // Gets the currently focused control.
        bool IsDataGridViewControl = (CurrentControl.GetType() == typeof(DataGridView)); // Checks if the currently focused control is a DataGridView control.
        bool IsComboBoxEditingControl = (CurrentControl.GetType() == typeof(DataGridViewComboBoxEditingControl)); // Checks if the currently focused control is a DataGridViewComboBoxEditingControl control.
        bool DataGridViewIsValid = (IsDataGridViewControl && dataGridViewDMSSettings.Rows.Count > -1); // Checks if a DataGridView control is focused is not empty.
        if
        (
            TabIsPressed // If a Tab key is pressed.
            && (
                DataGridViewIsValid // And a DataGridView is focused and valid.
                || IsComboBoxEditingControl // Or a DataGridViewComboBoxEditingControl is focused.
            )
        )
        {
            int CurrentRowIndex = dataGridViewDMSSettings.CurrentCell.RowIndex; // Gets the current rows index.
            int LastRowIndex = dataGridViewDMSSettings.RowCount - 1; // Gets the last rows index.
            if (IsComboBoxEditingControl) // If a DataGridViewComboBoxEditingControl is focused.
            {
                ((DataGridViewComboBoxEditingControl)CurrentControl).EditingControlDataGridView.EndEdit(); // Ends the editing mode for the control.
            }
            int NextRowIndex = CurrentRowIndex; // Creates a variable for the next rows index.
            switch (keyData) // Switches through the pressed keys.
            {
                case (Keys.Tab): // If the Tab key is pressed.
                    if (IsComboBoxEditingControl) // If a DataGridViewComboBoxEditingControl is focused.
                    {
                        NextRowIndex++; // Sets the next row index to the next row.
                        if (NextRowIndex > LastRowIndex) // If next row index is greater than the last row index.
                        {
                            NextRowIndex = 0; // Focuses the first row. (Alternatively call "base.ProcessCmdKey(ref msg, keyData)" to exit the DataGridView)
                        }
                    }
                    break;
                case (Keys.Shift | Keys.Tab): // If Shift and Tab key is pressed.
                    NextRowIndex--; // Sets the next row index to the previous row.
                    if (NextRowIndex < 0) // If previous row index is smaller than the first row index.
                    {
                        NextRowIndex = LastRowIndex; // Focuses the last row. (Alternatively call "base.ProcessCmdKey(ref msg, keyData)" to exit the DataGridView)
                    }
                    break;
            }
            dataGridViewDMSSettings.CurrentCell = dataGridViewDMSSettings.Rows[NextRowIndex].Cells["DMSIndex"]; // Sets the focus on the next DataGridViewComboBox.
            this.Refresh(); // Rerenders the current form.
            return true; // Returns true to the caller.
        }
        else // If another key (Not a Tab key) is pressed or the currently focused control is not a DataGridView or DataGridViewComboBoxEditing control.
        {
            return base.ProcessCmdKey(ref msg, keyData); // Performs the standard ProcessCmdKey method.
        }
    }
