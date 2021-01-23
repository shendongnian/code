    //your code on submission of the form...
    foreach (Control c in this.Controls)
    {
        if (c is TextBox)
        {                    
            ((TextBox)c).Clear();
            //c.Text = String.Empty;
        }
        if (c is ComboBox)
        {
            ((ComboBox)c).Items.Clear();
        }
    } 
