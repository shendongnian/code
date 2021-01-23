    protected override void OnKeyDown(KeyEventArgs e)
    {
        if(e.SystemKey == Key.F10)
        {
            mainMenuBar.Visibility = Visibility.Visible;
        }
        base.OnKeyDown(e);
    }
