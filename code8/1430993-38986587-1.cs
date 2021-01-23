    [Browsable(true)]
    public event EventHandler TextChanged
    {
        add { base.TextChanged += value; }
        remove { base.TextChanged -= value; }
    }
