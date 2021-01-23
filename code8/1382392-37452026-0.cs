    public event EventHandler CloseSplitViewPane;
    public void OnCloseSplitPaneView(object sender, EventArgs e)
    {
        CloseSplitViewPane?.Invoke(sender, e);
    }
