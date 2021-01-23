    public void UpdatePanel(Panel panel, Button button)
    {
        if(panel.InvokeRequired)
        {
            panel.Invoke(new Action<Panel,Button>(UpdatePanel), new object[] {panel, button});
        }
        else
        {
            panel.Controls.Add(button);
        }
    }
