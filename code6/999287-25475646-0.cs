    InitComboBox(comboBox1);
    InitComboBox(comboBox2);
    ...
    private void InitComboBox(ComboBox cb)
    {
        cb.Items.Add("K");
        cb.Items.Add("H");
        cb.Items.Add("L");
        cb.Items.Add("T");
        cb.SelectedIndex = 0;
    }
