    foreach (Control control in split.Panel2.Controls)
            {
                control.Dispose();
            }
    split.Panel2.Controls.Add(new ConfigurableMatrices(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString()));
    split.Panel2.Refresh();
