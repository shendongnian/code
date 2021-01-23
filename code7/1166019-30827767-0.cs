    public event EventHandler ShownEx;
    public void ShowEx()
    {
        Show();
        OnShownEx();
    }
    private void OnShownEx()
    {
        var eventHandler = ShownEx;
        if (eventHandler != null)
            eventHandler(this, EventArgs.Empty);
    }
