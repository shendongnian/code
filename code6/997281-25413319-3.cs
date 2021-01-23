    public static Control FindTargetTextbox(Control control, string targetName)
    {
        foreach (Control child in control.Controls)
        {
            if (child is TextBox && child.Name == targetName)
            {
                return child;
            }
            Control target = FindTargetComponent(child);
            if (target != null)
            {
                return target;
            }
        }
        return null;
    }
