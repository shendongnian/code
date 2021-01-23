    private void groupBox1_Validating(object sender, CancelEventArgs e)
    {
        foreach (Control control in groupBox1.Controls)
        {
            var textbox = control as TextBox;
            if (textbox != null)
            {
                ... do your processing of textboxes here
                continue;
            }
            var combobox = control as ComboBox;
            if (combobox != null)
            {
                ... do your processing of comboboxes here
                continue;
            }
            ... do your processing of other controls here
        }
    }
