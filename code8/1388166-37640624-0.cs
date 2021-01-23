        internal static void getComboSelectedIndex(Control control)
        {
            foreach (Control c in control.Controls)
            {
                getComboSelectedIndex(c);
                if (c is ComboBox)
                {
                    int i = ((ComboBox)c).SelectedIndex;
                    if (i > 0) MessageBox.Show("selected index of " + c.Name + " is " + i.ToString());
                }
            }
        }
