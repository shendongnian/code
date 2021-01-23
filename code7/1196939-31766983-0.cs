    if (NamePath.Text.Length == 0 && ThemePath.Text.Length == 0)
    {
        button1.Enabled = false;
    }
    else
    {
         button1.Enabled = true;
         label7.Text = "Press Button To Find a Match";
         label7.ForeColor = Color.PaleGreen;
    }
