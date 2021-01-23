    IEnumerable<Control> getAllControls(Control parent)
    {
        foreach (Control control in parent.Controls)
        {
            yield return control;
            foreach (Control descendant in getAllControls(control))
                yield return descendant;
        }
    }
