    /// <summary>
    ///     Positions children and returns the final size of the element.
    /// </summary>
    protected override Size ArrangeOverride(Size arrangeSize)
    {
        if (UsingBorderImplementation)
        {
            // Revert to the Border implementation
            return base.ArrangeOverride(arrangeSize);
        }
    
        UIElement child = Child;
        if (child != null)
        {
            // Use the public Padding property if it's set
            Thickness padding = Padding;
            if (padding.Equals(new Thickness()))
            {
                padding = DefaultPadding;
            }
    
            // Reserve space for the chrome
            double childWidth = Math.Max(0.0, arrangeSize.Width - padding.Left - padding.Right);
            double childHeight = Math.Max(0.0, arrangeSize.Height - padding.Top - padding.Bottom);
    
            child.Arrange(new Rect(padding.Left, padding.Top, childWidth, childHeight));
        }
    
        return arrangeSize;
    }
