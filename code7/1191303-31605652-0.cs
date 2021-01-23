    public CustonControl()
    {
        Loaded += HookToCtrlC;
    }
    private void HookToCtrlC(object sender, EventArgs e)
    {
        var parentWindow = Window.GetWindow(this);
        parentWindow.KeyDown += CopySelectedTextToClipboard;
    }
    private void CopyMarkedNucleotidesToClipboard(object sender, KeyEventArgs e)
    {
        Clipboard.SetText("Hello World!");
    }
