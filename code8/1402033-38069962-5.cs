    public void ClearPanels(GroupBox control)
    {
        foreach(ListBox listBox in control.Controls.OfType<ListBox>())
        {
            listBox.Items.Clear();
            // do more ListBox cleanup
        }
        foreach(CheckedListBox listBox in control.Controls.OfType<CheckedListBox>())
        {
            listBox.Items.Clear();
            // do more CheckedListBox cleanup
        }
        foreach(ListView listView in control.Controls.OfType<ListView>())
        {
            listView.Items.Clear();
            // do more ListView cleanup
        }
        foreach(CheckBox checkBox in control.Controls.OfType<CheckBox>())
        {
            checkBox.Checked = false;
            // do more CheckBox cleanup
        }
        // etc...
    }
