    private void FindMyControls(ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            if (control.Controls.Count > 0)
            {
                FindMyControls(c.Controls);
            }
            else
            {
                // it's a control without children of its own so
                // do something with it
            }
        }
    }
