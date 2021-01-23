    protected override void OnAttached()
    {
        base.OnAttached();
        this.AssociatedObject.PreviewKeyDown += _KeyBoardBehaviorKeyDown;
    }
    protected override void OnDetaching()
    {
        base.OnDetaching();
        this.AssociatedObject.PreviewKeyDown-= _KeyBoardBehaviorKeyDown;
    }
