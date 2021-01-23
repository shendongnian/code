    protected override int VisualChildrenCount
    {
        get { return thumb == null ? 0 : 1; }
    }
    protected override Visual GetVisualChild(int index)
    {
        if (_child == null)
        {
            throw new ArgumentOutOfRangeException();
        }
        return _child;
    }
