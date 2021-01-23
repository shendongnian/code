    static void AddControl(Control control, Func<Control> factory)
    {
        if (control.InvokeRequired)
        {
            control.BeginInvoke(
                new Action<Control, Func<Control>>(AddToControls), control, factory);
        }
        else
        {
            control.Controls.Add(factory());
        }
    }
