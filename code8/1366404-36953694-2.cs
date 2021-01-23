    public void PanelW(int panel)
    {
        foreach (var pb in this.Controls.OfType<Panel>())
            pb.Visible = pb.Name == "panel" + panel;
    }
