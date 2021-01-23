    public void CleartextBoxes(Control parent)
          {
            foreach (Control x in parent.Controls)
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
