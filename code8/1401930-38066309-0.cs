    foreach (Control child in Controls)
    {
        if (child.GetType() == typeof(TextBox))
        {
            TextBox tb = (TextBox)child;
            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.Text = @"N/A";
            }
        }
    }
