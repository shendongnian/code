    void registerAllControls(Control ctl)
    {
        ctl.Enter += ControlReceivedFocus;
        foreach (Control ct in ctl.Controls)
        {
            registerAllControls(ct);
        }
    }
