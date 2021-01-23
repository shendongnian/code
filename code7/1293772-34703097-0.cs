    private string patternToMatchIntegerValues = @"\d";
    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      my_datagridview.EditingControl.KeyPress -= EditingControl_KeyPress;
      my_datagridview.EditingControl.KeyPress += EditingControl_KeyPress;
    }
    private void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsControl(e.KeyChar))
      {
        var editingControl = (Control)sender;
        if (Regex.IsMatch(editingControl.Text + e.KeyChar, patternToMatchIntegerValues))
          // Stop the character from being entered into the control since it is non-numerical.
          e.Handled = true;
      }
    }
