    public void ClearPanels(GroupBox control)
    {
        foreach(Control childControl in control.Controls)
            childControl.ResetText();
    }
