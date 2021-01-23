    public static IEnumerable<Control> GetControlsRecursively(this Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            yield return c;
            if (c.HasControls())
            {
                foreach (Control control in c.GetControlsRecursively())
                {
                    yield return control;
                }
            }
        }
    }
