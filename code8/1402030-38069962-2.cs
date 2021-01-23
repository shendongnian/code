    public void ClearPanels(Control control)
    {
        foreach(Control childControl in control.Controls)
        {
            childControl.ResetText();
            ClearPanels(childControl); // recursive call
        }
    }
