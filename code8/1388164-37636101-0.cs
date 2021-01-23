    internal static void getComboSelectedIndex(Control control)
    {
    foreach (Control c in control.Controls)
    {
        if (c is ComboBox)
        {
            int i = ((ComboBox)c).SelectedIndex;
    MessageBox.Show("selected index of "+ c.name + " is "+ i.ToString());
        }
    }
    }
