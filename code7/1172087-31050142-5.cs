    public AggregateState State { get { return _state; } }
    public Type NextScreenType { get; private set; }
    public void Next()
    {
        NextScreenType = typeof(ScreenThreeViewModel); // Own type, because we have no next
        TryClose();
    }
    public void Previous()
    {
        NextScreenType = typeof(ScreenTwoViewModel);
        TryClose();
    }
