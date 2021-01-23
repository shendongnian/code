    public static Control FindFocusedControl(Control control)
    {
        var container = control as IContainerControl;
        while (container != null)
        {
            control = container.ActiveControl;
            container = control as IContainerControl;
        }
        return control;
    }
