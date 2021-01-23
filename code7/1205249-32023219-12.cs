    List<Control> controlSelection = new List<Control>();
    List<Control> getControls(Control container, Rectangle rect)
    {
        controlSelection = new List<Control>();
        foreach (Control ctl in container.Controls)
            if (rect.Contains(ctl.Bounds))
            {
                controlSelection.Add(ctl);
                foreach (Control ct in ctl.Controls) controlSelection.Add(ct); ;
            }
        return controlSelection;
    }
