    public AggregateState State { get { return _state; }  }
    public Type NextScreenType { get; private set; }
    public void Next()
    {
        if (!IsValid()) return;
        NextScreenType = typeof(ScreenTwoViewModel);
        TryClose();
    }
    public void Previous()
    {
        throw new NotImplementedException(); // Isn't needed in first screen, because we have no previous
    }
