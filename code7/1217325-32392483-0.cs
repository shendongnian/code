    foreach (Control c in this.Controls)
    {
        c.Enabled = false;
    }
    foreach (Control c in panel1.Controls)
    {
          c.Enabled = true;                    
    }
    panel1.Enabled = true;
