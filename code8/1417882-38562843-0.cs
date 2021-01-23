    [Category("Appearance")]
    public bool HasBorder
    {
        get
        {
            return HasBorder;
        }
        set
        {
            HasBorder = value; // will call setter again, which will call setter, which ...
            this.Invalidate();
        }
    }
