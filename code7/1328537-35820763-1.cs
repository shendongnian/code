    void SubscribeFocusToControls(Form form)
    {
        foreach (Control control in form.Controls)
        {
            control.Enter += control_Enter;
        }
    }
