    private object addedItem;
    private void CBwasher_CheckedChanged(object sender, EventArgs e)
    {
         if (checkBox1.Checked)
         {
              addedItem = comboBox1.SelectedItem;
              listBox2.Items.Add(addedItem);
         }
         else
         {
             listBox2.Items.Remove(addedItem);
         }
    }
