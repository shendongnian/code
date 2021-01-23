    void FillCombo(Control ctrl)
    {
        foreach (ComboBox cb in ctrl.Controls) 
        {
         cb.Items.Add("K");
        cb.Items.Add("H");
        cb.Items.Add("L");
        cb.Items.Add("T");
        cb.SelectedIndex = 0;
        }
    }
