    private void setEnabled(bool enabled)
    {
        ...
        combobox.Enabled = enabled;
        childControl.Enabled = combobox.Enabled;
        ...
    }
