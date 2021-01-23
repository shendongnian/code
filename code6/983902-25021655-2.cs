    public static IEnumerable<T> GetControlsRec<T>(Control.ControlCollection controlCollection)
        where T : Control
    {
        foreach (Control control in controlCollection)
        {
            if (control is T)
                yield return (T)control;
    
            if (control.HasChildren)
                foreach (T child in GetControlsRec(control.Controls))
                    yield return child;
        }
    }
