    bool _hasBorder;
    public bool HasBorder
    {
        get { return _hasBorder; }
        set
        {
            _hasBorder = value;
            Invalidate();
        }
    }
