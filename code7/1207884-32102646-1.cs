    void SetProperty(Control ctr)
    {
        foreach (Control control in ctr.Controls)
        {
            if (control is TextBox)
            {
                control.Leave += control_Leave;
            }
            else
            {
                if (control.HasChildren)
                {
                    SetProperty(control);
                }
            }
        }
    }
    void control_Leave(object sender, EventArgs e)
    {
        var textBox = sender as TextBox;
        Double value;
        if (Double.TryParse(textBox.Text, out value))
            textBox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
        else
            textBox.Text = String.Empty;
    }
