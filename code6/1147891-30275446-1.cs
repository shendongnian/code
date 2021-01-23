    int i = 0;    
    foreach (Control c in this.Controls)
    {
        if (c is ComboBox)
        {
            if (c.Text == 'USD')
                i++;
        }
    }
