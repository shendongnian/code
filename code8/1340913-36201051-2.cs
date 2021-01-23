    foreach (Control c in someControl.Controls)
    {
        if (c is Label)
        {
            ((Label)c).BackColor = Color.Red;
        }
    }
