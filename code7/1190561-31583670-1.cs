    public void CleartextBoxes(System.Web.UI.Control parent)
    {
        foreach (System.Web.UI.Control x in parent.Controls)
        {
            if ((x.GetType() == typeof(TextBox)))
            {
                ((TextBox)(x)).Text = "";
            }
            if (x.HasControls())
            {
                CleartextBoxes(x);
            }
        }
    }
