    for(int i = 0; i < 2; i++)
    {
        Panel p = this.Controls["panel" + i];
        foreach(Control c in p.Controls)
        {
            TextBox tb = c as TextBox;
            if(tb != null)
            {
                tb.TextChanged += textChanged;
            }
        }
    }
