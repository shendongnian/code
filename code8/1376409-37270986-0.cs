    public void EnableItems(IList<Component> cpnts)
    {
        foreach (Component cpnt in cpnts)
        {
            ToolStripItem tsItem = cpnt as ToolStripItem;
            if (tsItem != null) { tsItem.Enabled = true; break; }
            Control ctrl = cpnt as Control;
            if (ctrl != null) { ctrl.Enabled = true; break; }
        }
    }
