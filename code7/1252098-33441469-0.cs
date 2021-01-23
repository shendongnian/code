    foreach (Control c in Controls)
    {
        (c as Combobox)?.SelectedIndex = -1;
        (c as TextBox)?.Text = "";
        (c as CheckBox)?.Checked = false;
    }
