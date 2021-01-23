    IEnumerable<Control> getAllControls(Control parent)
    {
        foreach (Control control in parent.Controls)
        {
            yield return control;
            foreach (Control descendant in getAllControls(parent))
                yield return descendant;
        }
    }
