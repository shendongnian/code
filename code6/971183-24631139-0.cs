    foreach (Control c in this.Controls)
    {
        if (c is TextBox)
        {
            c.TextChanged += tb_TextChanged;
        }
    }
