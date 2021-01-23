    var invalidControls = form.Controls.Cast<Control>()
                              .Where(c => (c is TextBox || c is ComboBox) && c.Text == string.Empty);
    if (invalidControls.Any())
    {
        MessageBox.Show("Please fill all the fields", "Empty Fields",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
        invalidControls.First().Focus();
    }
