    public void DisableTextBoxes(Control tab)
    {
        foreach (Control control in tab.Controls)
        {
            if (control is TextBox)
            {
                TextBox tb = control as TextBox;
                tb.Enabled = false;
            }
            else
            {
                foreach (Control innerControl in control.Controls)
                {
                    DisableTextBoxes(control);
                }
            }
        }
    }
