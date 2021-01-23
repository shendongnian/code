    if (control is ASPxLabel)
    {
        string a = ((ASPxLabel)control).ID.Remove(((ASPxLabel)control).ID.Length - 4);
        ((ASPxLabel)control).Text = fonction1(a);
    }
    else if (control is ASPxTextBox)
    {
        string b = ((ASPxTextBox)control).ID.Remove(((ASPxTextBox)control).ID.Length - 4);
        ((ASPxTextBox)control).Text = fonction2(b);
    }
