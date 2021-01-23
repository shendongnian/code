    public static Control FindFocusedComponent(Control control)
    {
        foreach (Control child in control.Controls)
        {
            if (child.Focused)
            {
                return child;
            }
        }
        foreach (Control child in control.Controls)
        {
            Control focused = FindFocusedComponent(child);
            
            if (focused != null)
            {
                return focused;
            }
        }
        return null;
    }
