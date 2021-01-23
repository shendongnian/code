    public static void EmptyFields(UIElementCollection parent)
    {
        try
        {
            foreach (Control c in parent)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Text = string.Empty;
                }
                if (c.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)(c)).Text = string.Empty;
                }
                if (c.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)(c)).IsChecked = false;
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
