    public static IEnumerable<T> GetDecendentsOfType<T>(this Control c)
    {
        foreach (Control control in c.Controls)
        {
            if (control is T)
                yield return (T)control;
            if (control.HasChildren)
                foreach (T child in control.GetDecendentsOfType<T>())
                    yield return child;
        }
    }
