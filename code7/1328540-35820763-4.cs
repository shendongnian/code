    void SubscribeNestedControlsOnEnter(Control container)
    {
        foreach (Control control in container.Controls)
        {
            if (control.Controls.Count > 0)
            {
                SubscribeNestedControlsOnEnter(control);
            }
            else control.Enter += control_Enter;
        }
    }
