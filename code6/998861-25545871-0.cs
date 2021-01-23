    static VisibilityAnimation()
    {
        // Here we "register" on Visibility property "before change" event
        UIElement.VisibilityProperty.AddOwner(
            typeof(VisibilityAnimation),
            new FrameworkPropertyMetadata(
                Visibility.Visible,
                VisibilityChanged,
                CoerceVisibility));
    }
