    private TextBox GetTextBoxByName(string name)
    {
        foreach (Control control in Controls)
        {
            if (control.Name == name)
            {
                if (control is TextBox)
                {
                    return (TextBox)control;
                }
                else
                {
                    return null;
                }
            }
            if (control.HasChildren)
            {
                return GetTextBoxByName(name);
            }
        }
        return null;
    }
