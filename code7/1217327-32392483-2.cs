    foreach (Control c in this.Controls)
    {
        c.Enabled = false;
    }
    panel1.Parent.Enabled = true;
    foreach (Control c in panel1.Parent.Controls)
    {
        c.Enabled = false;
    }
    panel1.Enabled = true;
    
