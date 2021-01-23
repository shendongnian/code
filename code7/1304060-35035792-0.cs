    [Browsable(false)]
    public new event EventHandler Click
    {
        add { base.Click += value; }
        remove { base.Click -= value; }
    }
