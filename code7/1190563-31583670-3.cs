    public void CleartextBoxes(System.Windows.Forms.Control parent)
    {
        foreach (System.Windows.Forms.Control x in parent.Controls)
        {
            if ((x.GetType() == typeof(TextBox)))
            {
                ((TextBox)(x)).Text = "";
            }
            if (x.HasChildren)
            {
                CleartextBoxes(x);
            }
        }
    }
