    private void CBwasher_CheckedChanged(object sender, EventArgs e)
    {
         var checkBox = (CheckBox)sender;
         var comboBox = (ComboBox)checkBox.Tag;
         if (checkBox.Checked && comboBox.SelectedItem != null)
         {
              listBox2.Items.Add(comboBox.SelectedItem);
              comboBox.Tag = comboBox.SelectedItem;
         }
         if (!checkBox.Checked && comboBox.Tag != null)
         {
             listBox2.Items.Remove(comboBox.Tag);
         }
    }
