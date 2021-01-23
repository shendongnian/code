    private void SetLabelBlack(Control ctrl)
    {
        foreach (Control c in ctrl.Controls)
        {
            Label l = c as Label;
            if (l != null)
            {
                l.ForeColor = Color.Black;
            }
            else
            {
                SetLabelBlack(c);
            }
        }
    }
