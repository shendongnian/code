    public void StartButtonPressed(object senderView, EventArgs e)
    {
        GameView v = new GameView();
        UserControl old = SwitchView(v);
        if (old != null)
            old.Dispose();
    }
