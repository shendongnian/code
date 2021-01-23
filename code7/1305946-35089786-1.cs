    private void ChangeButtons(Control.ControlCollection controls)
    {
        for (int i = 0; i < controls.Count; i++)
        {
            // The control is a container so we need to look at this control's
            // children to see if there are any buttons inside of it.
            if (controls[i].HasChildren)
            {
                ChangeButtons(controls[i].Controls);
            }
            // Make sure the control is a button and if so disable it.
            if (controls[i] is Button)
            {
                ((Button)controls[i]).Text = "Hello";
            }
        }
    }
