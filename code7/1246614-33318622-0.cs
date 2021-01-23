    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
         if (Image == null)
            VisualStateManager.GoToState(this, "Preview", true);
        else
            VisualStateManager.GoToState(this, "Fullview", true);
    }
