    int i = 0;
    foreach (Control c in this.Controls)
    {
       if (c is TextBox)
        {
           i++;
           ((TextBox)c).Text = CleanInput(((TextBox)c).Text);
        }
    }
