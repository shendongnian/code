    public static IEnumerable<T> GetAllControls<T>(Control control)
    {
        var controls = control.Controls.OfType<T>();
        return control.Controls.Cast<Control>()
            .Aggregate(controls, (current, c) => current.Concat(GetAllControls<T>(c)));
    }
