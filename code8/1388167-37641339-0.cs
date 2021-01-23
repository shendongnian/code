    internal static void getComboSelectedIndex(Control control)
        {
            List<ComboBox> comboBoxes = new List<ComboBox>();
            foreach (Control c in control.Controls)
            {
                getComboSelectedIndex(c);
                if (c is ComboBox)
                {
                    ComboBox curretComboBox = ((ComboBox)c);
                    if (curretComboBox.SelectedIndex > -1) // should be greater than -1 not 0 because first index of comboboxes is 0 not 1
                    comboBoxes.Add(curretComboBox);
                }
            }
            var orderedList = comboBoxes.OrderBy(item => item.TabIndex).ToList();
            for (int i = 0; i < orderedList.Count; i++)
            {
                ComboBox _current = orderedList[i];
                MessageBox.Show("selected index of " + _current.Name + " is " + _current.SelectedIndex.ToString() + " / TabIndex: " + _current.TabIndex);
            }
        }
