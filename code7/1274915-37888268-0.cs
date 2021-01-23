    private void CreateControls(Control parent)
    {
        var method = parent.GetType().GetMethod("CreateControl",
                        BindingFlags.Instance | BindingFlags.NonPublic);
        if (!parent.Created)
            method.Invoke(parent, new object[] { true });
        else
            foreach (Control child in parent.Controls)
                CreateControls(child);
    }
