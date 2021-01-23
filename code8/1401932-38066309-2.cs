    foreach (Control child in Controls.OfType<TextBox>().ToList())
    {
         TextBox tb = (TextBox)child;
         if (string.IsNullOrEmpty(tb.Text))
         {
             tb.Text = @"N/A";
         }
    }
