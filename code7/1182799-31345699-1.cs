    private void Form_FormClosing(object sender, FormClosingEventArgs e)
    {
        var comboboxItems = new StringCollection();
        comboboxItems.AddRange(comboBox.Items.Cast<string>().ToArray());
        Properties.Settings.Default.ComboboxItems = comboboxItems;
        Properties.Settings.Default.Save();
    }
