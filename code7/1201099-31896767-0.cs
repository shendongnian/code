    private void SetControlVisibility(string controlName, bool visible)
    {
        // Searches through all controls inside your Form recursively by controlName
        Control control = GetControlByName(this.Controls, controlName);
        if (control != null)
            control.Visible = visible;
    }
    private Control GetControlByName(Control.ControlCollection controls, string controlName)
    {
        Control controlToFind = null;
        foreach (Control control in controls)
        {
            // If control is container like panel or groupBox, look inside it's child controls
            if (control.HasChildren)
            {
                controlToFind = GetControlByName(control.Controls, controlName);
                // If control is found inside child controls, break the loop
                // and return the control
                if (controlToFind != null)
                    break;
            }
            // If current control name is the name you're searching for, set control we're
            // searching for to that control, break the loop and return the control
            if (control.Name == controlName)
            {
                controlToFind = control;
                break;
            }
        }
        return controlToFind;
    }
