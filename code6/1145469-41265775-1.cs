    private void button1_Click(object sender, EventArgs e)
    {
        Control ctrl = GetControlByName(this, "archHalfRoundWindowGroup");
    }
    public Control GetControlByName(Control Ctrl, string Name)
    {
        Control ctrl = new Control();
        foreach (Control x in Ctrl.Controls)
        {
            if (x.Name == Name)
                return ctrl=x;
            if (x.Controls.Count > 0)
            {
                ctrl= GetControlByName(x, Name);
                if (ctrl.Name != "")
                    return ctrl;
            }
            if (ctrl.Name != "")
                return ctrl;
            }
            return ctrl;
        }
