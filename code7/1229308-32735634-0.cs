    if (toggleSwitch1.IsOn==true)
    {
        string a = EPF_NO.Text;
        EPF_NO.PasswordChar = '\0';
    }
    if (toggleSwitch1.IsOn==false)
    {
        EPF_NO.PasswordChar = '*';
    }
