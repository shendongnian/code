    public void ToggleControls()
    {
        foreach (Control c in this.Controls)
        {
            c.Enabled = !c.Enabled;
        }
    }
