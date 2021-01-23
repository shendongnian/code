    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        AdjustHeight();
    }
    private void AdjustHeight()
    {
        Rectangle screen = Screen.FromControl(this).WorkingArea;
        int screenHeight = screen.Height;
        if (screenHeight < Height)
        {
            Height = screenHeight;
            AdjustFormScrollbars(true); // not needed if AutoScroll property is true
        }
    }
